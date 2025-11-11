using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MySqlConnector;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public class WebServer : IDisposable
{
    private readonly string _connectionString;
    private readonly SerialService _serial;
    private readonly string _jwtKey;
    private readonly int _port;
    private Microsoft.AspNetCore.Hosting.WebHostBuilder _dummy; // placeholder
    private Microsoft.AspNetCore.Hosting.IWebHost _webHost;

    public WebServer(string connectionString, SerialService serial, string jwtKey, int port = 5000)
    {
        _connectionString = connectionString;
        _serial = serial;
        _jwtKey = jwtKey;
        _port = port;
    }

    public void Start()
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { Args = new string[0] });
        builder.WebHost.UseUrls($"http://0.0.0.0:{_port}");
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey)),
                ValidateLifetime = true
            };
        });
        builder.Services.AddAuthorization();
        builder.Services.AddCors(cors => cors.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

        var app = builder.Build();

        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();

        // -------- utilidades hashing ----------
        static byte[] HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
            var result = new byte[1 + salt.Length + hash.Length];
            result[0] = 0x01;
            Buffer.BlockCopy(salt, 0, result, 1, salt.Length);
            Buffer.BlockCopy(hash, 0, result, 1 + salt.Length, hash.Length);
            return result;
        }
        static bool VerifyPassword(string password, byte[] stored)
        {
            if (stored == null || stored.Length < 1) return false;
            byte[] salt = new byte[16];
            Buffer.BlockCopy(stored, 1, salt, 0, salt.Length);
            byte[] hashStored = new byte[32];
            Buffer.BlockCopy(stored, 1 + salt.Length, hashStored, 0, hashStored.Length);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);
            return CryptographicOperations.FixedTimeEquals(hash, hashStored);
        }

        // -------- Endpoints ----------
        app.MapPost("/api/login", async (HttpRequest req) =>
        {
            var obj = await req.ReadFromJsonAsync<LoginDto>();
            if (obj == null || string.IsNullOrWhiteSpace(obj.nombre) || string.IsNullOrWhiteSpace(obj.password))
                return Results.BadRequest(new { msg = "usuario/contraseña requeridos" });

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new MySqlCommand("SELECT id, password_hash FROM usuarios WHERE nombre=@n", conn);
            cmd.Parameters.AddWithValue("@n", obj.nombre);
            using var r = await cmd.ExecuteReaderAsync();
            if (!await r.ReadAsync()) return Results.Unauthorized();
            var id = r.GetInt32("id");
            var hash = (byte[])r["password_hash"];
            if (!VerifyPassword(obj.password, hash)) return Results.Unauthorized();

            // generar JWT simple
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwt = tokenHandler.WriteToken(token);
            return Results.Ok(new { token = jwt });
        });

        app.MapPost("/api/activar", (HttpRequest req) =>
        {
            // Aquí enviamos comando al Arduino (mismo que tu app)
            _serial.SendCommand("OPEN"); // ajusta según Arduino
            return Results.Ok(new { message = "Comando OPEN enviado" });
        }).RequireAuthorization();

        app.MapPost("/api/cerrar", (HttpRequest req) =>
        {
            _serial.SendCommand("CLOSE"); // ajusta según Arduino
            return Results.Ok(new { message = "Comando CLOSE enviado" });
        }).RequireAuthorization();

        app.MapGet("/api/tarjetas", async (HttpRequest req) =>
        {
            var lista = new List<object>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new MySqlCommand("SELECT id, uid, nombre, fecha_registro FROM tarjetas", conn);
            using var rr = await cmd.ExecuteReaderAsync();
            while (await rr.ReadAsync())
            {
                lista.Add(new { id = rr.GetInt32("id"), uid = rr.GetString("uid"), nombre = rr.GetString("nombre"), fecha_registro = rr["fecha_registro"] });
            }
            return Results.Ok(lista);
        }).RequireAuthorization();

        // Start the web app on a background thread so it doesn't block the UI
        Task.Run(() => app.Run());
    }

    public void Dispose()
    {
        try { _webHost?.StopAsync().Wait(500); _webHost?.Dispose(); }
        catch { }
    }

    public class LoginDto { public string nombre { get; set; } public string password { get; set; } }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace CafaFuerteInteligente
{
    public partial class Inicio : Form
    {
        SerialPort arduino;
        string conexionBD = "Server=localhost;Database=AdministradorSeguridad;Uid=root;Pwd=1234;";
        string uidTarjeta = "";

        public Inicio()
        {
            InitializeComponent();
            Estilos();
            CargarUsuarios();
            CargarTarjetas();
     
            arduino = new SerialPort("COM3", 9600); // Ajusta tu puerto
            arduino.DataReceived += Arduino_DataReceived;
           
            gbUN.Visible=false;
            gbUT.Visible=false;
            panelNuevos.Visible=false;
            PanelTarjetas.Visible = false;
            panelUsuarios.Visible = false;

        }
        private void VerificarTarjeta(string uid)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM tarjetas WHERE uid = @uid";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@uid", uid);
                    int existe = Convert.ToInt32(comando.ExecuteScalar());

                    if (existe > 0)
                    {
                        arduino.WriteLine("OK"); // Enviar comando a Arduino (LED verde)
                        this.Invoke(new Action(() =>
                        {
                            lblEstado.Text = $"✅ Tarjeta {uid} registrada";
                            lblEstado.ForeColor = Color.Green;
                        }));
                    }
                    else
                    {
                        arduino.WriteLine("NO"); // Enviar comando a Arduino (LED rojo)
                        this.Invoke(new Action(() =>
                        {
                            lblEstado.Text = $"❌ Tarjeta {uid} NO registrada";
                            lblEstado.ForeColor = Color.Red;
                        }));
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblEstado.Text = "Error: " + ex.Message;
                    }));
                }
            }
        }
        private void CargarUsuarios()
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                string query = "SELECT id, nombre, fecha_registro FROM usuarios";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvUsuarios.DataSource = tabla;
            }
        }
        private void CargarTarjetas()
        {
            using (MySqlConnection conexion= new MySqlConnection(conexionBD))
            {
                string leer = "SELECT id, nombre, fecha_registro From tarjetas";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(leer, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvTarjetas.DataSource = tabla;
            }
        }
        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = arduino.ReadLine().Trim();

                // 🟢 MODO REGISTRO: cuando estás escaneando para guardar tarjeta
                if (data.StartsWith("UID:"))
                {
                    uidTarjeta = data.Substring(4);
                    this.Invoke(new Action(() =>
                    {
                        lbluid.Text = "✅ Escaneo con éxito: " + uidTarjeta;
                    }));
                }

                // 🔵 MODO VERIFICACIÓN: cuando Arduino detecta una tarjeta en vigilancia
                else if (data.StartsWith("LEER:"))
                {
                    string uidDetectado = data.Substring(5);
                    VerificarTarjeta(uidDetectado); // 👈 Aquí se llama tu función
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    lblEstado.Text = "Error de lectura: " + ex.Message;
                    lblEstado.ForeColor = Color.Red;
                }));
            }
        }


        private void Estilos()
        {
            //Contraseña 
            txtContraN.UseSystemPasswordChar = true;
            //nada mas 
            btnNada.FlatStyle = FlatStyle.Flat;
            btnNada.FlatAppearance.BorderSize = 0;
            btnNada.Margin = new Padding(0);
            btnNada.Padding = new Padding(0);



            // Estilos base del DataGridView
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;

            // Encabezado (Header)
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // azul pastel
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsuarios.ColumnHeadersHeight = 35;

            // Celdas
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 232, 255); // azul claro al seleccionar
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvUsuarios.DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);

            // Filas
            dgvUsuarios.RowTemplate.Height = 30;
            dgvUsuarios.GridColor = Color.FromArgb(230, 230, 230); // líneas suaves

            //Tarjetas
            // Estilos base del DataGridView
            dgvTarjetas.BackgroundColor = Color.White;
            dgvTarjetas.BorderStyle = BorderStyle.None;
            dgvTarjetas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTarjetas.EnableHeadersVisualStyles = false;
            dgvTarjetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTarjetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTarjetas.MultiSelect = false;
            dgvTarjetas.AllowUserToAddRows = false;
            dgvTarjetas.AllowUserToResizeRows = false;
               
            // Tarjetasdo (Header)
            dgvTarjetas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // azul pastel
            dgvTarjetas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvTarjetas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dgvTarjetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTarjetas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTarjetas.ColumnHeadersHeight = 35;
               
            // Tarjetas
            dgvTarjetas.DefaultCellStyle.BackColor = Color.White;
            dgvTarjetas.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvTarjetas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 232, 255); // azul claro al seleccionar
            dgvTarjetas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dgvTarjetas.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgvTarjetas.DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
               
            // Tarjetas
            dgvTarjetas.RowTemplate.Height = 30;
            dgvTarjetas.GridColor = Color.FromArgb(230, 230, 230); // líneas suaves
        }
        //Nuevo usuario
        private void AgregarUsuario(string nombre, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string verify = "SELECT COUNT(*) FROM usuarios WHERE nombre=@nombre";
                    MySqlCommand checkCmd = new MySqlCommand(verify, conexion);
                    checkCmd.Parameters.AddWithValue("@nombre", nombre);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Ese nombre de usuario ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string query = "INSERT INTO usuarios (nombre, contrasena) VALUES (@nombre, @contrasena)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@contrasena", contrasena);
                    comando.ExecuteNonQuery();

                    MessageBox.Show("✅ Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(); // refresca la tabla
                    txtUserN.Clear();
                    txtContraN.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Termina nuevo usuario

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            PanelTarjetas.Visible = true;
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
            panelInicio.Visible = false;


        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panelNuevos.Visible=true;
            panelUsuarios.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;

        }
        //Panel Nuevos
        private void btnver_Click(object sender, EventArgs e)
        {
            txtContraN.UseSystemPasswordChar = !txtContraN.UseSystemPasswordChar;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtUserN.Text.Trim();
            string contrasena = txtContraN.Text.Trim();
            AgregarUsuario(nombre, contrasena);

        }

        private void btnNTarjeta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uidTarjeta))
            {
                MessageBox.Show("Primero escanea una tarjeta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNT.Text))
            {
                MessageBox.Show("Ingresa un nombre para la tarjeta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO tarjetas (uid, nombre, fecha_registro) VALUES (@uid, @nombre, NOW())";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@uid", uidTarjeta);
                    comando.Parameters.AddWithValue("@nombre", txtNT.Text);
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Tarjeta guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNT.Clear();
                    lbluid.Text = "Listo para nueva lectura.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en base de datos: " + ex.Message);
                }
            }
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!arduino.IsOpen)
                    arduino.Open();

                lbluid.Text = "Esperando tarjeta...";
                uidTarjeta = "";
                arduino.WriteLine("SCAN"); // Enviamos comando a Arduino
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el lector: " + ex.Message);
            }
        }

        private void btnmostrarNT_Click(object sender, EventArgs e)
        {
            gbUT.Visible = true;
            gbUN.Visible = false;
        }
        private void btnmostarNU_Click(object sender, EventArgs e)
        {
            gbUN.Visible = true;
            gbUT.Visible = false;

            
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            panelInicio.Visible = true;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelUsuarios.Visible = false;
        }
    }
}

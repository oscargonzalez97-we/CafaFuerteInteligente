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
            CargarRegistros();
            dgvRegistros.CellFormatting += dgvRegistros_CellFormatting;

            try
            {
                // ✅ Crear instancia del puerto
                arduino = new SerialPort();

                // Configurar puerto serie
                arduino.PortName = "COM4"; // Asegúrate que sea el correcto
                arduino.BaudRate = 9600;
                arduino.DataReceived += Arduino_DataReceived;

                if (!arduino.IsOpen)
                    arduino.Open();

                lblEstado.Text = "Conectado al Arduino. Escaneando tarjetas...";
                lblEstado.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al conectar con Arduino: " + ex.Message;
                lblEstado.ForeColor = Color.Red;
            }
            gbUN.Visible=false;
            gbUT.Visible=false;
            panelNuevos.Visible=false;
            PanelTarjetas.Visible = false;
            panelUsuarios.Visible = false;
            PanelRegistros.Visible = false;


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
                        arduino.WriteLine("OK"); 
                        this.Invoke(new Action(() =>
                        {
                            lblEstado.Text = $"✅ Tarjeta {uid} registrada";
                            lblEstado.ForeColor = Color.Green;
                        }));
                    }
                    else
                    {
                        arduino.WriteLine("NO");
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
                string data = arduino.ReadExisting().Trim();

                // 🔹 Dividir por saltos de línea si llegan varios mensajes juntos
                string[] lineas = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string linea in lineas)
                {
                    string mensaje = linea.Trim();

                    // Ignorar READY u otras palabras de inicialización
                    if (string.IsNullOrEmpty(mensaje) || mensaje.ToUpper() == "READY")
                        continue;

                    // Filtrar UID válido (solo HEX y longitud esperada)
                    if (System.Text.RegularExpressions.Regex.IsMatch(mensaje, "^[0-9A-Fa-f]{8,}$"))
                    {
                        string uidDetectado = mensaje.ToUpper();

                        this.Invoke(new Action(() =>
                        {
                            lblEstado.Text = $"Tarjeta detectada: {uidDetectado}";
                            lblEstado.ForeColor = Color.DarkOrange;
                        }));

                        bool registrada = false;

                        using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                        {
                            conexion.Open();
                            string query = "SELECT COUNT(*) FROM tarjetas WHERE UPPER(uid) = @uid";
                            MySqlCommand comando = new MySqlCommand(query, conexion);
                            comando.Parameters.AddWithValue("@uid", uidDetectado);
                            int count = Convert.ToInt32(comando.ExecuteScalar());
                            registrada = count > 0;
                        }

                        if (registrada)
                        {
                            arduino.WriteLine("green");
                            this.Invoke(new Action(() =>
                            {
                                lblEstado.Text = $"✅ Tarjeta {uidDetectado} registrada";
                                lblEstado.ForeColor = Color.Green;
                            }));
                        }
                        else
                        {
                            arduino.WriteLine("red");
                            this.Invoke(new Action(() =>
                            {
                                lblEstado.Text = $"❌ Tarjeta {uidDetectado} NO registrada";
                                lblEstado.ForeColor = Color.Red;
                            }));
                        }

                        RegistrarAcceso(uidDetectado, registrada);
                    }
                    else
                    {
                        // Mensaje no válido (ruido serial)
                        this.Invoke(new Action(() =>
                        {
                            lblEstado.Text = $"Ignorado: {mensaje}";
                            lblEstado.ForeColor = Color.Gray;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    lblEstado.Text = "Error en comunicación: " + ex.Message;
                    lblEstado.ForeColor = Color.Red;
                }));
            }
        }

        private void RegistrarAcceso(string uid, bool permitido)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionBD))
    {
                conexion.Open();

                string query = @"
            INSERT INTO registros (fecha, hora, uid_tarjeta, estado)
            VALUES (CURDATE(), CURTIME(), @uid_tarjeta, @estado)";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@uid_tarjeta", uid);
                comando.Parameters.AddWithValue("@estado", permitido ? "PERMITIDO" : "DENEGADO");
                comando.ExecuteNonQuery();
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
                    CargarUsuarios(); 
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
                arduino.WriteLine("SCAN"); 
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

       //Botones del menu
        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            panelInicio.Visible = true;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelUsuarios.Visible = false;
            PanelRegistros.Visible = false;
            label8.Visible = true;
            label6.Visible = true;
            lblEstado.Visible = true;
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;
            PanelRegistros.Visible = false;
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {

            PanelTarjetas.Visible = true;
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
            panelInicio.Visible = true;
            PanelRegistros.Visible = false;
            label8.Visible = false;
            label6.Visible = false;
            lblEstado.Visible = false;
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            PanelRegistros.Visible = true;
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;
        }
        private void CargarRegistros()
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string query = "SELECT fecha AS 'Fecha', hora AS 'Hora', estado AS 'Estado' FROM registros ORDER BY id_registro DESC";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dgvRegistros.DataSource = tabla;

                    dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvRegistros.ReadOnly = true;
                    dgvRegistros.AllowUserToAddRows = false;
                    dgvRegistros.RowHeadersVisible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRegistros.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                if (estado.Equals("PERMITIDO", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (estado.Equals("DENEGADO", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void btnNuevos_Click(object sender, EventArgs e)
        {

            panelNuevos.Visible = true;
            panelUsuarios.Visible = false;
            PanelTarjetas.Visible = false;
            panelInicio.Visible = false;
        }


        //Termina botones el menu 
        //Botones para usuario

        int idUsuarioSeleccionado = -1;
        private void btnBuscarU_Click(object sender, EventArgs e)
        {
            string nombreBuscar = txtUser.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreBuscar))
            {
                MessageBox.Show("Por favor, ingresa un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool encontrado = false;
            idUsuarioSeleccionado = -1;

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.Cells["nombre"].Value != null &&
                    fila.Cells["nombre"].Value.ToString().Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                {
                    fila.Selected = true;
                    fila.DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvUsuarios.FirstDisplayedScrollingRowIndex = fila.Index;

                    idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);
                    encontrado = true;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }

            if (encontrado)
            {
                MessageBox.Show($"Usuario '{nombreBuscar}' encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int idTarjetaSeleccionada = -1;
        private void btnEliminarU_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == -1)
            {
                MessageBox.Show("Por favor busca un usuario antes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    try
                    {
                        conexion.Open();
                        string query = "DELETE FROM usuarios WHERE id = @id";
                        MySqlCommand comando = new MySqlCommand(query, conexion);
                        comando.Parameters.AddWithValue("@id", idUsuarioSeleccionado);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        idUsuarioSeleccionado = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            string nombreBuscar = txtBuscarTarjeta.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreBuscar))
            {
                MessageBox.Show("Por favor, ingresa un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool encontrado = false;
            idTarjetaSeleccionada = -1;

            foreach (DataGridViewRow fila in dgvTarjetas.Rows)
            {
                if (fila.Cells["nombre"].Value != null &&
                    fila.Cells["nombre"].Value.ToString().Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                {
                    fila.Selected = true;
                    fila.DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvTarjetas.FirstDisplayedScrollingRowIndex = fila.Index;

                    idTarjetaSeleccionada = Convert.ToInt32(fila.Cells["id"].Value);
                    encontrado = true;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }

            if (encontrado)
            {
                MessageBox.Show($"Tarjeta '{nombreBuscar}' encontrada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tarjeta no encontrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarT_Click(object sender, EventArgs e)
        {
            if (idTarjetaSeleccionada == -1)
            {
                MessageBox.Show("Por favor busca una tarjeta antes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar esta tarjeta?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    try
                    {
                        conexion.Open();
                        string query = "DELETE FROM tarjetas WHERE id = @id";
                        MySqlCommand comando = new MySqlCommand(query, conexion);
                        comando.Parameters.AddWithValue("@id", idTarjetaSeleccionada);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Tarjeta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTarjetas(); // refresca la tabla
                        idTarjetaSeleccionada = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar tarjeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ✅ SE AGREGA ESTO ABAJO DEL CONSTRUCTOR
        
    }
}

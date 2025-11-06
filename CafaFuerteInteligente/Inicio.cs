using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CafaFuerteInteligente
{
    public partial class Inicio : Form
    {
        string conexionBD = "Server=localhost;Database=AdministradorSeguridad;Uid=root;Pwd=1234;";
        public Inicio()
        {
            InitializeComponent();
            Estilos();
            CargarUsuarios();
            panelUsuarios.Visible= false;
            gbUN.Visible=false;
            gbUT.Visible=false;
            panelNuevos.Visible=false;
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

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = false;
            panelNuevos.Visible = false;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panelNuevos.Visible=true;
            panelUsuarios.Visible = false;
        }
        //Panel Nuevos
        private void btnmostarNU_Click(object sender, EventArgs e)
        {
            gbUN.Visible = true;
            gbUT.Visible = false;
        }

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
    }
}

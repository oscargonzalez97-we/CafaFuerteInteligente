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

    public partial class Form1 : Form
    {
        string conexionBD = "Server=localhost;Database=AdministradorSeguridad;Uid=root;Pwd=1234;";

        public Form1()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private void AplicarEstilo()
        {
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.BackColor = Color.White;
            txtUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            txtUsuario.Font = new Font("Segoe UI", 11);

            txtContra.BorderStyle = BorderStyle.None;
            txtContra.UseSystemPasswordChar = true;
            txtContra.BackColor = Color.White;
            txtContra.ForeColor = Color.FromArgb(30, 30, 30);
            txtContra.Font = new Font("Segoe UI", 11);



        }

        private void btnver_Click(object sender, EventArgs e)
        {
            txtContra.UseSystemPasswordChar = !txtContra.UseSystemPasswordChar;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingresa un nombre valido");
                return;
            }
            string contra = txtContra.Text.Trim();
            if (string.IsNullOrEmpty(contra)) { MessageBox.Show("Ingresa una contraseña valida"); return; }

            if (usuario == "" || contra == "")
            {
                MessageBox.Show("Por favor ingresa usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexionBD))
                {
                    conn.Open();
                    string query = "select * from usuarios Where nombre= @usuario AND contrasena= @contra";
                    using (MySqlCommand insertar = new MySqlCommand(query, conn))
                    {
                        insertar.Parameters.AddWithValue("@usuario",usuario);
                        insertar.Parameters.AddWithValue("@contra", contra);
                        MySqlDataReader reader = insertar.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Inicio inicio = new Inicio();
                            inicio.Show();
                            this.Hide();


                        }
                        else
                        {
                            MessageBox.Show("No registrado", "No has podido accesar", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    }
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de conexion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
    }
}

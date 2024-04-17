using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCaja
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }


        private bool AutenticarUsuario(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            bool autenticado = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AutenticarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@N_Usuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Contrasena_Usuario", usuario.Contrasena);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        autenticado = count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al autenticar: " + ex.Message);
                    }
                }
            }
            return autenticado;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = txtUsuario.Text,
                Contrasena = txtContraseña.Text
            };

            bool exito = AutenticarUsuario(nuevoUsuario);

            if (exito)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();

                Main mainForm = new Main();
                mainForm.Show();

                // Cerrar el formulario actual
                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtUsuario.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("El nombre de usuario solo puede contener letras y números, sin espacios ni caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length > 6 || txtContraseña.Text.Contains(" "))
            {
                if (txtContraseña.Text.Length > 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("La contraseña no puede contener espacios en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }
    }
}
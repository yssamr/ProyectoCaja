using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCaja
{
    public partial class RegistrarCajero : Form
    {
        private void RegistrarCajero_Load(object sender, EventArgs e)
        {

        }

        public RegistrarCajero()
        {
            InitializeComponent();
        }

        public int contadorAdmin = 1, contadorCajero = 1;

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdmin.Checked)
            {
                txtUsuario.Text = "Admin" + contadorAdmin.ToString("00");
            }
            else
            {
                txtUsuario.Text = "";
            }
        }

        private void rbCajero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCajero.Checked)
            {
                txtUsuario.Text = "Cajero" + contadorCajero.ToString("00");
            }
            else
            {
                txtUsuario.Text = "";
            }
        }

        private void cbPolitica_CheckedChanged(object sender, EventArgs e)
        {
            btnRegistrarse.Enabled = cbPolitica.Checked; // Habilitar o deshabilitar el botón de registro según el estado del checkbox
            if (!cbPolitica.Checked)
            {
                MessageBox.Show("Por favor, recuerde aceptar las políticas para poder registrarse.", "Políticas de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length > 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                (rbCajero.Checked == false && rbAdmin.Checked == false) ||
                comboBoxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                Cedula = txtCedula.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Rol = rbCajero.Checked ? "Cajero" : "Administrador",
                NombreUsuario = txtUsuario.Text, 
                Contrasena = txtContraseña.Text,
                IDSucursal = comboBoxSucursal.SelectedItem.ToString()
            };

            bool exito = InsertarUsuario(nuevoUsuario);

            if (exito)
            {
                if (exito)
                {
                    if (rbCajero.Checked)
                    {
                        contadorCajero++;
                    }
                    else
                    {
                        contadorAdmin++;
                    }

                    MessageBox.Show("¡Sus datos han sido guardados exitosamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al intentar guardar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            rbAdmin.Checked = false;
            rbCajero.Checked = false;
        }
        

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            string texto = txtNombres.Text;
            bool esValido = texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (!esValido)
            {
                MessageBox.Show("Por favor, ingrese un nombre válido. Solo se permiten letras y espacios.", "Error de nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            string texto = txtApellidos.Text;
            bool esValido = texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (!esValido)
            {
                MessageBox.Show("Por favor, ingrese apellidos válidos. Solo se permiten letras y espacios.", "Error de apellidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCedula.Text;

            if (texto.Length > 11 || !texto.All(c => char.IsDigit(c)))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida. Solo se permiten números.", "Error de cédula", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string texto = txtTelefono.Text;

            if (texto.Length > 12 || !texto.All(c => char.IsDigit(c) || c == '-'))
            {
                MessageBox.Show("Por favor, ingrese un teléfono válido. Solo se permiten números y guiones.", "Error de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private bool InsertarUsuario(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            string storedProcedure = "InsertarUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Cedula_Usuario", usuario.Cedula);
                    command.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombres);
                    command.Parameters.AddWithValue("@Apellido_Usuario", usuario.Apellidos);
                    command.Parameters.AddWithValue("@Direccion_Usuario", usuario.Direccion);
                    command.Parameters.AddWithValue("@Telefono_Usuario", usuario.Telefono);
                    command.Parameters.AddWithValue("@Contrasena_Usuario", usuario.Contrasena);
                    command.Parameters.AddWithValue("@Rol_Usuario", usuario.Rol);
                    command.Parameters.AddWithValue("@N_Usuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@ID_Sucursal", usuario.IDSucursal);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();
                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                        // Si llegamos hasta aquí, la inserción fue exitosa
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Si hay un error, mostrarlo y devolver false
                        MessageBox.Show("Error al insertar usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
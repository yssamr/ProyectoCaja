using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCaja
{
    public partial class RegistrarCajero : Form
    {
        string nombres, apellidos, cedula, telefono, direccion, usuario, sucursal, contraseña, opcionRadioButton, rolUsuario;
        bool politicas = false;

        private void cbPolitica_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolitica.Checked)
            {
                politicas = true;
            }
            else
            {
                politicas = false;
            }
        }

        private void rbCajero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCajero.Checked)
            {
                opcionRadioButton = "Cajero";
            }
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAdmin.Checked)
            {
                opcionRadioButton = "Administrador";
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            nombres = txtNombres.Text;
            apellidos = txtApellidos.Text;
            cedula = txtCedula.Text;
            telefono = txtTelefono.Text;
            direccion = txtDireccion.Text;
            usuario = txtUsuario.Text;
            sucursal = comboBoxSucursal.SelectedIndex.ToString();
            contraseña = txtContraseña.Text;
            rolUsuario = opcionRadioButton;

            MessageBox.Show("¡Sus datos han sido guardados exitosamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public RegistrarCajero()
        {
            InitializeComponent();
        }

        private void RegistrarCajero_Load(object sender, EventArgs e)
        {

        }

        private void txtIDCajero_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPoliticas_Click(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnentsali_Click(object sender, EventArgs e)
        {
            EntradaySalidaDeEfectivo entradaysalida = new EntradaySalidaDeEfectivo();
            entradaysalida.Show();
        }

        private void btnpagodeefectivo_Click(object sender, EventArgs e)
        {
            PagoProductos pagoProductos = new PagoProductos();
            pagoProductos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AperturaCaja aperturaCaja = new AperturaCaja();
            aperturaCaja.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pendiente hacer el cierre de caje
            CuadreCaja cuadreCaja = new CuadreCaja();
            cuadreCaja.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            iniciarSesion.Show();
            //this.Hide();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CuadreCaja cuadreCaja1 = new CuadreCaja();  
            cuadreCaja1.Show(); 

        }
    }
}

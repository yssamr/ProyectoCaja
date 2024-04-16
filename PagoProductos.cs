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
    public partial class PagoProductos : Form
    {
        public PagoProductos()
        {
            InitializeComponent();
        }

        private void PagoProductos_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // Intervalo en milisegundos
            timer.Tick += (s, _) =>
            {
                lblHoraActual.Text = DateTime.Now.ToLongTimeString(); // Actualizar la hora
                lblFechaActual.Text = DateTime.Now.ToLongDateString(); // Actualizar la fecha
            };
            timer.Start();
        }
    }
}
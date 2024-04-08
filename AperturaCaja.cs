using System;
using System.Windows.Forms;

namespace AppCaja
{
    public partial class AperturaCaja : Form
    {
        public AperturaCaja()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Agregar filas al DataGridView
            dataGridView1.Rows.Add("Billetes de $1000.00");
            dataGridView1.Rows.Add("Billetes de $500.00");
            dataGridView1.Rows.Add("Billetes de $200.00");
            dataGridView1.Rows.Add("Billetes de $100.00");
            dataGridView1.Rows.Add("Billetes de $50.00");
            dataGridView1.Rows.Add("Monedas de $25.00");
            dataGridView1.Rows.Add("Monedas de $10.00");
            dataGridView1.Rows.Add("Monedas de $5.00");
            dataGridView1.Rows.Add("Monedas de $1.00");

        }

        private void lblFechaApertura_Click(object sender, EventArgs e)
        {

        }
    }
}

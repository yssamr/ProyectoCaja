using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCaja
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new IniciarSesion());
            //Application.Run(new AperturaCaja());
            //Application.Run(new PagoProductos());
            Application.Run(new RegistrarCajero());
            Application.Run(new RegistrarCajero());
        }
    }
}

using sisCafetería.capaPresentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Inicio());

            Login loginForm = new Login();


            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Inicio());
            }
        }
    }
}

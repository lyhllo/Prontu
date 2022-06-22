using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.View;
using PRONTU.Controller;

namespace PRONTU
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (UsuarioController.ExisteUsuario())
            {
                Application.Run(new Login());
            } else
            {
                Application.Run(new NovoUsuario());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiFaceRec
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new FrmDangNhap());                     
            }
            catch { }
        }
    }
}

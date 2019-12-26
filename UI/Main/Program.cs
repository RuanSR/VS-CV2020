using Business.Class;
using System;
using System.Windows.Forms;
using UI.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SysSettings.Init();
            Application.Run(new frmPrincipal());
        }
    }
}

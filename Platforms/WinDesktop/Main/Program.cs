using System;
using System.Windows.Forms;
using WinDesktop.Forms;

namespace WinDesktop
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
            try
            {
                //SysSettings.VerificaBanco();
                // new DbManager().Init();
                //AppManager.Init();
                Application.Run(new FrmPrincipal());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no sistema! {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}

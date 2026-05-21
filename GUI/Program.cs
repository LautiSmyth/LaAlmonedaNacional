using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += (s, e) =>
                MessageBox.Show($"Error inesperado:\n{e.Exception.Message}",
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                MessageBox.Show($"Error fatal:\n{((Exception)e.ExceptionObject).Message}",
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Run(new FormMenu());
        }
    }
}
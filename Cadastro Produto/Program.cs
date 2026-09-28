using System;
using System.Windows.Forms;

namespace Cadastro_Produto
{
    internal static class Program
    {
        // Ponto de entrada da aplicacao
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

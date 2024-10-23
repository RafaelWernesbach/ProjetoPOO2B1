using System; // Importa o namespace System
using System.Windows.Forms; // Importa o namespace para Windows Forms
using Banco; // Importa o namespace do seu projeto Banco
using static System.Windows.Forms.DataFormats; // Importa os formatos de dados do Windows Forms

namespace SeuNamespace // Define um namespace para a aplicação
{
    static class Program // Classe Program que contém o método Main
    {
        [STAThread] // Indica que o aplicativo usa um modelo de thread single-threaded para interface do usuário
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita estilos visuais para a aplicação
            Application.SetCompatibleTextRenderingDefault(false); // Define o modo de renderização de texto
            Application.Run(new TelaBanco()); // Inicia a aplicação com a TelaBanco como o formulário principal
        }
    }
}



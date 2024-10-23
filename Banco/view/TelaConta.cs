using System;
using System.Windows.Forms;
using Banco.control; // Importa o namespace que contém os controladores
using Banco.model.clientes; // Importa o namespace que contém a classe Cliente

namespace Banco.view
{
    public partial class TelaConta : Form
    {
        private BancoController bancoController; // Controlador do banco

        // Construtor que inicializa a tela de conta com os controladores necessários
        public TelaConta(BancoController bancoController)
        {
            InitializeComponent();
            MaximizeBox = false; // Desabilita o botão de maximizar
            FormBorderStyle = FormBorderStyle.FixedSingle; // Define a borda como fixa
            this.bancoController = bancoController; // Armazena o controlador
        }

        // Método que trata o evento de clique no botão para abrir uma nova conta
        private void button1_Click(object sender, EventArgs e)
        {
            string documento = textBox1.Text; // Documento do cliente
            string numero = textBox3.Text; // Número da conta
            string tipo = " "; // Inicializa o tipo da conta

            // Verifica se pelo menos um tipo de conta foi selecionado
            if (!(checkBox1.Checked || checkBox2.Checked))
            {
                MessageBox.Show("Marque o tipo da conta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro
            }
            else
            {
                // Define o tipo de conta com base nas checkboxes
                if (checkBox1.Checked)
                {
                    tipo = "corrente"; // Tipo corrente selecionado
                }
                else if (checkBox2.Checked)
                {
                    tipo = "poupanca"; // Tipo poupança selecionado
                }

                // Chama o método para abrir a conta
                bancoController.AbrirConta(documento, numero, tipo);
            }
        }

        // Método que trata a alteração do estado da checkBox1
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Se a checkBox1 for marcada, desativa a checkBox2
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false; // Desativa checkBox2
            }
            else
            {
                checkBox2.Enabled = true;  // Reativa checkBox2
            }
        }

        // Método que trata a alteração do estado da checkBox2
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Se a checkBox2 for marcada, desativa a checkBox1
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false; // Desativa checkBox1
            }
            else
            {
                checkBox1.Enabled = true;  // Reativa checkBox1
            }
        }

        // Método que trata o evento de clique no botão para remover uma conta
        private void button2_Click(object sender, EventArgs e)
        {
            string numero = textBox4.Text; // Número da conta a ser removida
            bancoController.getContaController().RemoverConta(numero); // remove a conta
        }

        // Método que trata o evento de clique no botão para exibir os detalhes de uma conta
        private void button3_Click(object sender, EventArgs e)
        {
            string numero = textBox5.Text; // Número da conta a ser exibida
            bancoController.getContaController().ExibirConta(numero); // Exibe os detalhes da conta
        }

        // Método que trata o evento de clique no botão para fechar a conta com base em outro número
        private void button4_Click(object sender, EventArgs e)
        {
            string numero = textBox2.Text; // Número da conta a ser fechada
            bancoController.getContaController().FecharConta(numero); // Fecha a conta
        }
    }
}

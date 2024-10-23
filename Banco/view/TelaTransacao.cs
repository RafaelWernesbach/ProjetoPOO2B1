using System;
using System.Windows.Forms;
using Banco.model.contas; // Importa o namespace que contém a classe Conta
using Banco.control; // Importa o namespace que contém os controladores

namespace Banco.view
{
    public partial class TelaTransacao : Form
    {
        private BancoController bancoController; // Controlador do banco

        // Construtor que inicializa a tela de transação com os controladores necessários
        public TelaTransacao(BancoController bancoController)
        {
            InitializeComponent();
            MaximizeBox = false; // Desabilita o botão de maximizar
            FormBorderStyle = FormBorderStyle.FixedSingle; // Define a borda como fixa
            this.bancoController = bancoController; // Armazena o controlador
        }

        // Método que trata o evento de clique no botão para executar uma transação
        private void button1_Click(object sender, EventArgs e)
        {
            string numeroOrigem = textBox1.Text; // Número da conta de origem
            string numeroDestino = textBox2.Text; // Número da conta de destino
            string tipo = textBox3.Text; // Tipo da transação (depósito, saque, transferência, etc.)
            string valor = textBox4.Text; // Valor da transação

            // Chama o método do controlador para realizar a transação
            bancoController.RealizarTransacao(numeroOrigem, numeroDestino, tipo, valor);
        }
    }
}

using System;
using System.Windows.Forms;
using Banco.model.clientes; // Importa o namespace para a classe Cliente
using Banco.control; // Importa o namespace para os controladores

namespace Banco.view
{
    public partial class TelaCliente : Form
    {
        private BancoController bancoController; // Controlador para gerenciar clientes

        // Construtor que inicializa a tela de cliente com o controlador
        public TelaCliente(BancoController bancoController)
        {
            InitializeComponent();
            MaximizeBox = false; // Desabilita o botão de maximizar
            FormBorderStyle = FormBorderStyle.FixedSingle; // Define a borda como fixa
            this.bancoController = bancoController; // Armazena o controlador
        }

        // Método que trata o evento de clique no botão para adicionar um novo cliente
        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text; // Nome do cliente
            string documento = textBox2.Text; // Documento do cliente
            string tipo = textBox3.Text; // Tipo de documento

            bancoController.getClienteController().AdicionarCliente(nome, documento, tipo); // Adiciona o cliente
        }

        // Método que trata o evento de clique no botão para remover um cliente
        private void button2_Click(object sender, EventArgs e)
        {
            string documento = textBox5.Text; // Documento do cliente a ser removido
            bancoController.getClienteController().RemoverCliente(documento); // Remove o cliente
        }

        // Método que trata o evento de clique no botão para exibir os detalhes de um cliente
        private void button3_Click(object sender, EventArgs e)
        {
            string documento = textBox4.Text; // Documento do cliente a ser exibido
            bancoController.getClienteController().ExibirCliente(documento); // Exibe os detalhes do cliente
        }

        // Método que trata o evento de clique no botão para listar contas do cliente
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; // Limpa a fonte de dados do DataGridView
            string documento = textBox6.Text; // Documento do cliente para listar suas contas
            dataGridView1.DataSource = bancoController.ListarContasCliente(documento); // Lista as contas do cliente
        }
    }
}

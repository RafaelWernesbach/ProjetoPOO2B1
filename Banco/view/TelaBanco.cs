using Banco.view; // Importa as views do banco
using Banco.control; // Importa os controladores do banco
using Banco.model; // Importa o modelo do banco

namespace Banco
{
    public partial class TelaBanco : Form
    {
        private BancoController bancoController; // Controlador principal do banco
        private TelaCliente telaCliente; // Tela para gerenciar clientes
        private TelaConta telaConta; // Tela para gerenciar contas
        private TelaTransacao telaTransacao; // Tela para gerenciar transações

        public TelaBanco()
        {
            InitializeComponent();

            MaximizeBox = false; // Desabilita o botão de maximizar
            FormBorderStyle = FormBorderStyle.FixedSingle; // Define a borda como fixa
            Bancasso banco = new Bancasso(); // Inicializa o banco
            bancoController = new BancoController(banco); // Inicializa o controlador do banco
            telaCliente = new TelaCliente(bancoController); // Inicializa a tela de cliente
            telaConta = new TelaConta(bancoController); // Inicializa a tela de conta
            telaTransacao = new TelaTransacao(bancoController); // Inicializa a tela de transação
        }

        private void button1_Click(object sender, EventArgs e)
        {
            telaCliente.ShowDialog(); // Abre a tela de cliente
        }

        private void button2_Click(object sender, EventArgs e)
        {
            telaConta.ShowDialog(); // Abre a tela de conta
        }

        private void button3_Click(object sender, EventArgs e)
        {
            telaTransacao.ShowDialog(); // Abre a tela de transação
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; // Limpa a fonte de dados do DataGridView
            dataGridView1.DataSource = bancoController.ListarClientes(); // Lista os clientes no DataGridView
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; // Limpa a fonte de dados do DataGridView
            dataGridView1.DataSource = bancoController.ListarContas(); // Lista as contas no DataGridView
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; // Limpa a fonte de dados do DataGridView
            dataGridView1.DataSource = bancoController.ListarTransacoes(); // Lista as transações no DataGridView
        }
    }
}

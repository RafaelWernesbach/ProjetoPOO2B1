using System;
using Banco.model;
using Banco.model.clientes;
using Banco.model.contas; // Importa o namespace que contém a classe Bancasso

namespace Banco.control
{
    // A classe BancoController coordena os controladores de clientes, contas e transações,
    // centralizando a lógica do banco e facilitando a interação com os dados.
    public class BancoController
    {
        private ClienteController clienteController; // Controlador para gerenciar clientes
        private ContaController contaController; // Controlador para gerenciar contas
        private TransacaoController transacaoController; // Controlador para gerenciar transações

        // Construtor que inicializa os controladores com base na instância do banco
        public BancoController(Bancasso banco)
        {
            clienteController = new ClienteController(banco.GetGerenciadorDeClientes());
            contaController = new ContaController(banco.GetGerenciadorDeContas());
            transacaoController = new TransacaoController(banco.GetGerenciadorDeTransacoes());
        }

        // Métodos para obter os controladores de clientes, contas e transações
        public ClienteController getClienteController() // Alterado para PascalCase
        {
            return clienteController;
        }

        public ContaController getContaController() // Alterado para PascalCase
        {
            return contaController;
        }

        public TransacaoController getTransacaoController() // Alterado para PascalCase
        {
            return transacaoController;
        }

        public void AbrirConta(string documento, string numero, string tipo)
        {
            Cliente cliente = clienteController.BuscarCliente(documento);
            if (cliente == null)
            {
                MessageBox.Show("Cliente com esse documento não existe", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se o cliente não for encontrado
            }
            else
            {
                contaController.AbrirConta(cliente, numero, tipo); // Abre a conta para o cliente encontrado
            }
        }

        public void RealizarTransacao(string numeroOrigem, string numeroDestino, string tipo, string valor)
        {
            Conta contaDestino = contaController.BuscarConta(numeroDestino); // Busca a conta de destino
            Conta contaOrigem = contaController.BuscarConta(numeroOrigem); // Busca a conta de origem
            bool ok = double.TryParse(valor, out double valorok); // Tenta converter o valor para double

            // Verifica se a conversão foi bem-sucedida e executa a transação
            if (ok)
            {
                transacaoController.ExecutarTransacao(tipo, contaOrigem, contaDestino, valorok); // Executa a transação
            }
            else
            {
                MessageBox.Show("Valor inválido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se o valor for inválido
            }
        }

        public List<Cliente> ListarClientes()
        {
            return clienteController.PassarClientes(); // Retorna a lista de clientes
        }

        public IEnumerable<dynamic> ListarContas()
        {
            return contaController.PassarContas().Select(conta => new
            {
                Numero = conta.Numero,
                Saldo = conta.Saldo,
                Titular = conta.Titular.Nome,
                Status = conta.Status,
                Tipo = conta.Tipo   // Cria um objeto anônimo com os dados das contas
            }).ToList();
        }

        public IEnumerable<dynamic> ListarTransacoes()
        {
            return transacaoController.PassarTransacoes().Select(transacao => new
            {
                Tipo = transacao.Tipo,
                Data = transacao.Data,
                Valor = transacao.Valor,
                ContaDestino = transacao.ContaDestino?.Numero ?? "N/A", // Verifica se ContaDestino é null e atribui "N/A" se for
                ContaOrigem = transacao.ContaOrigem?.Numero ?? "N/A",   // Verifica se ContaOrigem é null e atribui "N/A" se for
                DestinoTitular = transacao.ContaDestino?.Titular?.Nome ?? "N/A", // Verifica se Titular de ContaDestino é null e atribui "N/A" se for
                OrigemTitular = transacao.ContaOrigem?.Titular?.Nome ?? "N/A"    // Verifica se Titular de ContaOrigem é null e atribui "N/A" se for
            }).ToList();
        }

        public IEnumerable<dynamic> ListarContasCliente(string documento)
        {
            return contaController.BuscarContas(documento).Select(conta => new
            {
                Numero = conta.Numero,
                Saldo = conta.Saldo,
                Titular = conta.Titular.Nome,
                Status = conta.Status,
                Tipo = conta.Tipo   // Cria um objeto anônimo com os dados das contas
            }).ToList();
        }
    }
}

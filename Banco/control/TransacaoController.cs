using System;
using System.Collections.Generic;
using Banco.model.transacoes; // Importa o namespace para as transações
using Banco.model.clientes; // Importa o namespace para clientes
using Banco.model.contas; // Importa o namespace para contas
using System.Windows.Forms; // Necessário para usar MessageBox

namespace Banco.control
{
    // A classe TransacaoController gerencia a lógica relacionada às transações financeiras,
    // permitindo a execução de depósitos, saques, transferências e empréstimos.
    public class TransacaoController
    {
        private GerenciadorDeTransacoes gerenciadorDeTransacoes; // Gerenciador de transações

        // Construtor que inicializa o gerenciador de transações
        public TransacaoController(GerenciadorDeTransacoes gerenciadorDeTransacoes)
        {
            this.gerenciadorDeTransacoes = gerenciadorDeTransacoes; // Atribui o gerenciador recebido ao campo da classe
        }

        // Método para executar uma transação com base no tipo especificado
        public void ExecutarTransacao(string tipo, Conta contaOrigem, Conta contaDestino, double valor)
        {
            try
            {
                if (contaOrigem == null && contaDestino == null)
                {
                    throw new ArgumentException("Insira pelo menos uma conta de origem ou destino válida"); // Verifica se pelo menos uma conta é válida
                }

                ITransacao transacao;
                switch (tipo.ToLower())
                {
                    case "deposito":
                        if (contaDestino == null || contaDestino.Status == "Encerrada")
                        {
                            throw new ArgumentException("Conta de destino não pode ser fechada ou nula para depósitos."); // Verifica se a conta de destino é válida
                        }
                        transacao = new Deposito(contaDestino, valor, tipo); // Cria um depósito
                        break;
                    case "saque":
                        if (contaOrigem == null || contaOrigem.Status == "Encerrada")
                        {
                            throw new ArgumentException("Conta de origem não pode ser fechada ou nula para saques."); // Verifica se a conta de origem é válida
                        }
                        transacao = new Saque(contaOrigem, valor, tipo); // Cria um saque
                        break;
                    case "transferencia":
                        if (contaDestino == null || contaOrigem == null || contaDestino.Status == "Encerrada" || contaOrigem.Status == "Encerrada")
                        {
                            throw new ArgumentException("Conta de destino ou origem não podem ser fechadas ou nulas para transferências."); // Verifica se as contas são válidas
                        }
                        transacao = new Transferencia(contaOrigem, contaDestino, valor, tipo); // Cria uma transferência
                        break;
                    case "emprestimo":
                        if (contaDestino == null || contaDestino.Status == "Encerrada")
                        {
                            throw new ArgumentException("Conta de destino não pode ser nula para empréstimos."); // Verifica se a conta de destino é válida
                        }
                        if (contaDestino is ContaCorrente contaCorrente)
                        {
                            if (contaCorrente.Saldo < 0)
                            {
                                throw new InvalidOperationException("Empréstimo não permitido para contas utilizando o limite de cheque especial."); // Verifica se a conta está no negativo
                            }
                        }
                        transacao = new Emprestimo(contaDestino, valor, 10.5, tipo); // Cria um empréstimo
                        break;
                    default:
                        throw new ArgumentException("Tipo de transação inválida"); // Lança exceção para tipos inválidos
                }

                // Efetua a transação e a adiciona ao gerenciador
                transacao.Efetuar(); // Executa a transação
                gerenciadorDeTransacoes.AdicionarTransacao(transacao); // Adiciona a transação ao gerenciador
                MessageBox.Show("Transação efetuada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de sucesso
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Erro na transação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado na transação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
        }

        // Método para listar todas as transações
        public List<ITransacao> PassarTransacoes()
        {
            try
            {
                return gerenciadorDeTransacoes.GetTransacoes(); // Retorna a lista de transações
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar transações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return new List<ITransacao>(); // Retorna uma lista vazia em caso de erro
            }
        }
    }
}

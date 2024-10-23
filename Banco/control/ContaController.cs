using System;
using System.Collections.Generic;
using Banco.model.contas; // Importa o namespace para a classe Conta
using Banco.model.clientes; // Importa o namespace para a classe Cliente
using System.Windows.Forms; // Necessário para usar MessageBox

namespace Banco.control
{
    // A classe ContaController gerencia a lógica relacionada às contas bancárias,
    // permitindo abrir, consultar, fechar e exibir informações sobre as contas.
    public class ContaController
    {
        private GerenciadorDeContas gerenciadorDeContas; // Gerenciador de contas

        // Construtor que inicializa o gerenciador de contas
        public ContaController(GerenciadorDeContas gerenciadorDeContas)
        {
            this.gerenciadorDeContas = gerenciadorDeContas; // Atribui o gerenciador recebido ao campo da classe
        }

        // Método para abrir uma nova conta
        public void AbrirConta(Cliente cliente, string numero, string tipo)
        {
            try
            {
                // Verifica se o número da conta já está em uso
                if (BuscarConta(numero) != null)
                {
                    throw new Exception("Esse número já está sendo utilizado"); // Lança exceção se o número já estiver em uso
                }
                if (tipo == "corrente")
                {
                    Conta novaConta = new ContaCorrente(numero, 0, cliente, 500); // Cria uma nova conta corrente
                    gerenciadorDeContas.AdicionarConta(novaConta); // Adiciona a nova conta ao gerenciador
                }
                else if (tipo == "poupanca")
                {
                    Conta novaConta = new Poupanca(numero, 0, cliente); // Cria uma nova conta poupança
                    gerenciadorDeContas.AdicionarConta(novaConta); // Adiciona a nova conta ao gerenciador
                }

                MessageBox.Show("Conta Aberta Com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
        }

        // Método para consultar o saldo de uma conta
        public double ConsultarSaldo(string numeroConta)
        {
            try
            {
                foreach (Conta conta in gerenciadorDeContas.GetContas())
                {
                    if (conta.Numero == numeroConta)
                    {
                        return conta.Saldo; // Retorna o saldo se a conta for encontrada
                    }
                }
                throw new ArgumentException("Conta não encontrada"); // Lança exceção se a conta não for encontrada
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return 0; // Retorna 0 como valor padrão
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar saldo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return 0; // Retorna 0 como valor padrão em caso de erro
            }
        }

        // Método para remover uma conta
        public void RemoverConta(string numeroConta)
        {
            try
            {
                Conta conta = BuscarConta(numeroConta);
                if (conta != null)
                {
                    gerenciadorDeContas.RemoverConta(conta); // Remove a conta se encontrada
                    MessageBox.Show("Conta Removida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de sucesso
                }
                else
                {
                    MessageBox.Show("Conta não encontrada", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se a conta não for encontrada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
        }

        // Método para fechar conta
        public void FecharConta(string numero)
        {
            try
            {
                Conta conta = BuscarConta(numero);
                if (conta != null)
                {
                    gerenciadorDeContas.AlterarStatus(conta, "Encerrada"); // Altera o status da conta para encerrada
                    MessageBox.Show("Conta Fechada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de sucesso
                }
                else
                {
                    MessageBox.Show("Conta não encontrada", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se a conta não for encontrada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fechar a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
        }

        // Método para buscar contas pelo documento do titular
        public List<Conta> BuscarContas(string documento)
        {
            try
            {
                List<Conta> contas = new List<Conta>(); // Inicializa lista de contas
                foreach (Conta conta in gerenciadorDeContas.GetContas())
                {
                    if (conta.Titular.Documento == documento)
                    {
                        contas.Add(conta); // Adiciona a conta à lista se o documento coincidir
                    }
                }
                return contas; // Retorna lista de contas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return null; // Retorna null em caso de erro
            }
        }

        // Método para buscar uma conta pelo número
        public Conta BuscarConta(string numero)
        {
            try
            {
                foreach (Conta conta in gerenciadorDeContas.GetContas())
                {
                    if (conta.Numero == numero)
                    {
                        return conta; // Retorna a conta encontrada
                    }
                }
                return null; // Retorna null se não encontrar a conta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return null; // Retorna null em caso de erro
            }
        }

        // Método para exibir os detalhes de uma conta em uma MessageBox
        public void ExibirConta(string numero)
        {
            try
            {
                Conta conta = BuscarConta(numero);

                if (conta == null)
                {
                    MessageBox.Show("Conta não encontrada", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se a conta não for encontrada
                }
                else
                {
                    // Mensagem com os detalhes da conta
                    string mensagem = $"Titular: {conta.Titular.Nome}\n" +
                                      $"Documento do titular: {conta.Titular.Documento}\n" +
                                      $"Número: {conta.Numero}\n" +
                                      $"Saldo: {conta.Saldo}";

                    MessageBox.Show(mensagem, "Detalhes da Conta", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe os detalhes da conta
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir a conta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
            }
        }

        // Método para passar a lista de contas
        public List<Conta> PassarContas()
        {
            try
            {
                return gerenciadorDeContas.GetContas(); // Retorna a lista de contas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao passar a lista de contas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe mensagem de erro
                return new List<Conta>(); // Retorna uma lista vazia em caso de erro
            }
        }
    }
}

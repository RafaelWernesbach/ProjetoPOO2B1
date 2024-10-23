using System;
using System.Collections.Generic;
using Banco.model.clientes; // Importa o namespace para a classe Cliente
using System.Windows.Forms; // Necessário para usar MessageBox

namespace Banco.control
{
    // A classe ClienteController é responsável pela lógica de controle relacionada aos clientes,
    // permitindo adicionar, buscar, remover e exibir informações dos clientes.
    public class ClienteController
    {
        private GerenciadorDeClientes gerenciadorDeClientes; // Gerenciador de clientes

        // Construtor que inicializa o gerenciador de clientes
        public ClienteController(GerenciadorDeClientes gerenciadorDeClientes)
        {
            this.gerenciadorDeClientes = gerenciadorDeClientes; // Atribui o gerenciador recebido ao campo da classe
        }

        // Método para adicionar um novo cliente
        public void AdicionarCliente(string nome, string documento, string tipoDocumento)
        {
            try
            {
                // Verifica se todos os campos obrigatórios estão preenchidos
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(documento) ||
                    string.IsNullOrWhiteSpace(tipoDocumento) || !(tipoDocumento == "cpf" || tipoDocumento == "cnpj"))
                {
                    throw new ArgumentException("Todos os campos devem ser preenchidos corretamente."); // Lança exceção se algum campo estiver vazio
                }

                // Verifica se já existe um cliente com o mesmo documento
                if (BuscarCliente(documento) != null)
                {
                    throw new InvalidOperationException("Cliente com o mesmo documento já existe."); // Lança exceção se o cliente já existir
                }
                else
                {
                    // Cria um novo cliente e adiciona ao gerenciador
                    Cliente cliente = new Cliente(nome, documento, tipoDocumento);
                    gerenciadorDeClientes.AdicionarCliente(cliente); // Adiciona o cliente ao gerenciador
                    MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe a mensagem de erro
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe a mensagem de erro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para buscar um cliente pelo documento
        public Cliente BuscarCliente(string documento)
        {
            try
            {
                foreach (Cliente cliente in gerenciadorDeClientes.GetClientes())
                {
                    if (cliente.Documento == documento)
                    {
                        return cliente; // Retorna o cliente encontrado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null; // Retorna null se não encontrar o cliente
        }

        // Método para remover um cliente pelo documento
        public void RemoverCliente(string documento)
        {
            try
            {
                Cliente clienteEncontrado = BuscarCliente(documento);

                if (clienteEncontrado != null)
                {
                    gerenciadorDeClientes.RemoverCliente(clienteEncontrado); // Remove o cliente se encontrado
                    MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new ArgumentException("Cliente não encontrado"); // Lança exceção se o cliente não for encontrado
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe a mensagem de erro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar remover o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para retornar a lista de clientes
        public List<Cliente> PassarClientes()
        {
            try
            {
                return gerenciadorDeClientes.GetClientes(); // Retorna a lista de clientes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao retornar a lista de clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Cliente>(); // Retorna uma lista vazia em caso de erro
            }
        }

        // Método para exibir detalhes de um cliente em uma MessageBox
        public void ExibirCliente(string documento)
        {
            try
            {
                Cliente cliente = BuscarCliente(documento);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensagem de erro se o cliente não for encontrado
                }
                else
                {
                    // Mensagem com os detalhes do cliente
                    string mensagem = $"Nome: {cliente.Nome}\n" +
                                      $"Documento: {cliente.Documento}\n" +
                                      $"Tipo: {cliente.TipoDocumento}";

                    MessageBox.Show(mensagem, "Detalhes do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe os detalhes do cliente
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

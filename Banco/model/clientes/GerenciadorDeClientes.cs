using System;
using System.Collections.Generic;

namespace Banco.model.clientes
{
    // A classe GerenciadorDeClientes é responsável pela persistência dos clientes.
    // Ela oferece métodos básicos para adicionar e remover clientes da lista gerenciada.
    public class GerenciadorDeClientes
    {
        private List<Cliente> clientes; // Lista que armazena os clientes

        // Construtor que inicializa a lista de clientes
        public GerenciadorDeClientes()
        {
            clientes = new List<Cliente>(); // Inicializa a lista de clientes
        }

        // Método para adicionar um novo cliente à lista
        public void AdicionarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");

            clientes.Add(cliente); // Adiciona o cliente à lista
        }

        // Método para remover um cliente da lista
        public void RemoverCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");

            clientes.Remove(cliente); // Remove o cliente da lista
        }

        // Método para obter a lista de clientes
        public List<Cliente> GetClientes()
        {
            return clientes; // Retorna a lista de clientes
        }
    }
}

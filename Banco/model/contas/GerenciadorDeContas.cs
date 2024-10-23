using System;
using System.Collections.Generic;

namespace Banco.model.contas
{
    // A classe GerenciadorDeContas é responsável pelo gerenciamento da persistência das contas bancárias.
    // Ela possui métodos para adicionar e remover contas da lista de contas gerenciadas.
    public class GerenciadorDeContas
    {
        private List<Conta> contas; // Lista que armazena as contas gerenciadas

        // Construtor que inicializa a lista de contas
        public GerenciadorDeContas()
        {
            contas = new List<Conta>(); // Inicializa a lista de contas
        }

        // Método para adicionar uma nova conta à lista
        public void AdicionarConta(Conta conta)
        {
            if (conta == null)
                throw new ArgumentNullException(nameof(conta), "Conta não pode ser nula.");

            contas.Add(conta); // Adiciona a conta à lista
        }

        // Método para remover uma conta da lista
        public void RemoverConta(Conta conta)
        {
            if (conta == null)
                throw new ArgumentNullException(nameof(conta), "Conta não pode ser nula.");

            contas.Remove(conta); // Remove a conta da lista
        }

        // Método para alterar o status de uma conta
        public void AlterarStatus(Conta conta, string status)
        {
            if (conta == null)
                throw new ArgumentNullException(nameof(conta), "Conta não pode ser nula.");

            conta.SetStatus(status); // Altera o status da conta
        }

        // Método para obter a lista de contas
        public List<Conta> GetContas()
        {
            return contas; // Retorna a lista de contas
        }
    }
}

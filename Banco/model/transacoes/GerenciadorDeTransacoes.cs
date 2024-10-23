using System;
using System.Collections.Generic;

namespace Banco.model.transacoes
{
    // A classe GerenciadorDeTransacoes gerencia uma lista de transações no sistema.
    // Permite adicionar, remover e acessar as transações registradas.
    public class GerenciadorDeTransacoes
    {
        private List<ITransacao> transacoes; // Lista que armazena as transações

        // Construtor que inicializa a lista de transações
        public GerenciadorDeTransacoes()
        {
            transacoes = new List<ITransacao>(); // Inicializa a lista de transações
        }

        // Método para adicionar uma nova transação à lista
        public void AdicionarTransacao(ITransacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao), "Transação não pode ser nula.");

            transacoes.Add(transacao); // Adiciona a transação à lista
        }

        // Método para remover uma transação da lista
        public void RemoverTransacao(ITransacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao), "Transação não pode ser nula.");

            transacoes.Remove(transacao); // Remove a transação da lista
        }

        // Método que retorna a lista de transações
        public List<ITransacao> GetTransacoes()
        {
            return transacoes; // Retorna a lista de transações
        }
    }
}

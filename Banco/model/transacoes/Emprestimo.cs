using System;
using Banco.model.contas; // Importa o namespace que contém a classe Conta

namespace Banco.model.transacoes
{
    // A classe Emprestimo representa uma transação de empréstimo, onde um valor é emprestado e depositado em uma conta.
    // Implementa a interface ITransacao e possui propriedades para data, valor, conta de destino e taxa de juros.
    internal class Emprestimo : ITransacao
    {
        public DateTime Data { get; private set; } // Data do empréstimo
        public double Valor { get; private set; } // Valor do empréstimo
        public Conta ContaOrigem => null; // Não se aplica a empréstimos, sempre é null
        public Conta ContaDestino { get; private set; } // Conta que recebe o valor do empréstimo
        public string Tipo { get; private set; } // Tipo de transação
        public double TaxaDeJuros { get; private set; } // Taxa de juros do empréstimo

        public Emprestimo(Conta contaDestino, double valor, double taxaDeJuros, string tipo)
        {
            if (contaDestino == null)
                throw new ArgumentNullException(nameof(contaDestino), "Conta de destino não pode ser nula.");

            if (valor <= 0)
                throw new ArgumentException("O valor do empréstimo deve ser maior que zero.", nameof(valor));

            if (taxaDeJuros < 0)
                throw new ArgumentException("A taxa de juros não pode ser negativa.", nameof(taxaDeJuros));

            ContaDestino = contaDestino; // Inicializa a conta de destino
            Valor = valor; // Inicializa o valor do empréstimo
            Data = DateTime.Now; // Define a data do empréstimo como a data e hora atuais
            Tipo = tipo; // Inicializa o tipo de transação
            TaxaDeJuros = taxaDeJuros; // Inicializa a taxa de juros
        }

        public void Efetuar() // Método que efetua o empréstimo
        {
            ContaDestino.Depositar(Valor); // Adiciona o valor do empréstimo à conta de destino
        }
    }
}

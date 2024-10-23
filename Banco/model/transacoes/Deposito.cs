using System;
using Banco.model.contas; // Importa o namespace que contém a classe Conta

namespace Banco.model.transacoes
{
    // A classe Deposito representa uma transação de depósito, onde um valor é depositado em uma conta.
    // Implementa a interface ITransacao e possui propriedades para data, valor e conta de destino.
    public class Deposito : ITransacao
    {
        public DateTime Data { get; private set; } // Data do depósito
        public double Valor { get; private set; } // Valor do depósito
        public Conta ContaOrigem => null; // Não se aplica a depósitos, sempre é null
        public Conta ContaDestino { get; private set; } // Conta que recebe o valor do depósito
        public string Tipo { get; private set; } // Tipo de transação

        // Construtor da classe Deposito
        public Deposito(Conta contaDestino, double valor, string tipo)
        {
            
            if (contaDestino == null)
                throw new ArgumentNullException(nameof(contaDestino), "Conta de destino não pode ser nula.");

            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.", nameof(valor));

            ContaDestino = contaDestino; // Inicializa a conta de destino
            Valor = valor; // Inicializa o valor do depósito
            Data = DateTime.Now; // Define a data do depósito como a data e hora atuais
            Tipo = tipo; // Inicializa o tipo de transação
        }

        // Método que efetua o depósito
        public void Efetuar()
        {
            ContaDestino.Depositar(Valor); // Adiciona o valor do depósito à conta de destino
        }
    }
}

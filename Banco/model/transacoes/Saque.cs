using System;
using Banco.model.contas; // Importa o namespace que contém a classe Conta

namespace Banco.model.transacoes
{
    // A classe Saque representa uma transação de saque de uma conta.
    // Implementa a interface ITransacao e contém propriedades para data, valor e a conta de origem.
    public class Saque : ITransacao
    {
        public DateTime Data { get; private set; } // Data do saque
        public double Valor { get; private set; } // Valor do saque
        public Conta ContaOrigem { get; private set; } // Conta de onde o valor será retirado
        public Conta ContaDestino => null; // Não se aplica a saques, sempre é null
        public string Tipo { get; private set; } // Tipo de transação

        public Saque(Conta contaOrigem, double valor, string tipo)
        {
            if (contaOrigem == null)
                throw new ArgumentNullException(nameof(contaOrigem), "Conta de origem não pode ser nula.");

            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));

            ContaOrigem = contaOrigem; // Inicializa a conta de origem
            Valor = valor; // Inicializa o valor do saque
            Data = DateTime.Now; // Define a data do saque como a data e hora atuais
            Tipo = tipo; // Inicializa o tipo de transação
        }

        public void Efetuar()
        {
            ContaOrigem.Sacar(Valor); // Retira o valor da conta de origem
        }
    }
}

using System;
using Banco.model.contas; // Importa o namespace que contém a classe Conta

namespace Banco.model.transacoes
{
    // Classe Transferencia representa uma transação que movimenta valores entre duas contas.
    // Implementa a interface ITransacao e contém propriedades para data, valor e contas envolvidas.
    internal class Transferencia : ITransacao
    {
        public DateTime Data { get; private set; } // Data da transferência
        public double Valor { get; private set; } // Valor da transferência
        public Conta ContaOrigem { get; private set; } // Conta de onde o valor será retirado
        public Conta ContaDestino { get; private set; } // Conta para onde o valor será depositado
        public string Tipo { get; private set; } // Tipo de transação

        public Transferencia(Conta contaOrigem, Conta contaDestino, double valor, string tipo)
        {
            ContaOrigem = contaOrigem; // Inicializa a conta de origem
            ContaDestino = contaDestino; // Inicializa a conta de destino
            Valor = valor; // Inicializa o valor da transferência
            Data = DateTime.Now; // Define a data da transferência como a data e hora atuais
            Tipo = tipo; // Inicializa o tipo de transação
        }

        public void Efetuar() // Método que efetua a transferência entre as contas
        {
            ContaOrigem.Sacar(Valor); // Retira o valor da conta de origem
            ContaDestino.Depositar(Valor); // Adiciona o valor à conta de destino
        }
    }
}


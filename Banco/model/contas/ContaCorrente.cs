using Banco.model.clientes;
using System.Windows.Forms; // Certifique-se de incluir essa diretiva se for usar MessageBox

namespace Banco.model.contas
{
    // A classe ContaCorrente herda de Conta e implementa os métodos abstratos.
    public class ContaCorrente : Conta
    {
        public double LimiteChequeEspecial { get; private set; } // Limite de cheque especial

        // Construtor da ContaCorrente
        public ContaCorrente(string numero, double saldo, Cliente titular, double limiteChequeEspecial)
            : base(numero, saldo, titular)
        {
            LimiteChequeEspecial = limiteChequeEspecial;
            Tipo = "Conta Corrente"; // Define o tipo da conta
        }

        // Implementação do método para depositar
        public override void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.", nameof(valor));

            Saldo += valor; // Adiciona o valor ao saldo
        }

        // Implementação do método para sacar, considerando o cheque especial
        public override void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));

            if (Saldo + LimiteChequeEspecial >= valor)
            {
                Saldo -= valor; // Subtrai o valor do saldo
            }
            else
            {
                MessageBox.Show("Saldo Insuficiente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Cheque Especial Estourado!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

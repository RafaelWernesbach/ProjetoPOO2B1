using Banco.model.clientes;
using System.Windows.Forms; // Certifique-se de incluir essa diretiva se for usar MessageBox

namespace Banco.model.contas
{
    // A classe Poupanca herda de Conta e implementa os métodos abstratos.
    public class Poupanca : Conta
    {
        // Construtor da Poupanca
        public Poupanca(string numero, double saldo, Cliente titular)
            : base(numero, saldo, titular)
        {
            Tipo = "Poupança"; // Define o tipo da conta
        }

        // Implementação do método para depositar
        public override void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.", nameof(valor));

            Saldo += valor; // Adiciona o valor ao saldo
        }

        // Implementação do método para sacar, sem cheque especial
        public override void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));

            if (Saldo >= valor)
            {
                Saldo -= valor; // Subtrai o valor do saldo
            }
            else
            {
                MessageBox.Show("Saldo Insuficiente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

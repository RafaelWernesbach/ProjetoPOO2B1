using Banco.model.clientes;

namespace Banco.model.contas
{
    // A classe abstrata Conta define a estrutura básica para as contas bancárias.
    public abstract class Conta
    {
        // Atributos protegidos para que as classes filhas possam acessá-los
        public string Numero { get; protected set; } // Número da conta
        public double Saldo { get; protected set; }  // Saldo atual da conta
        public Cliente Titular { get; protected set; } // Cliente titular da conta
        public string Status { get; protected set; }  // Status da conta (ex: Ativa, Inativa)
        public string Tipo { get; protected set; } // Tipo da conta

        // Construtor protegido para que apenas as subclasses possam instanciar
        protected Conta(string numero, double saldo, Cliente titular)
        {
            Numero = numero;
            Saldo = saldo;
            Titular = titular;
            Status = "Ativa"; // Status padrão
        }

        // Métodos abstratos que devem ser implementados pelas classes filhas
        public abstract void Depositar(double valor);
        public abstract void Sacar(double valor);

        // Método protegido opcional para encerrar a conta
        public void SetStatus(string status)
        {
            Status = status; // Define o novo status da conta
        }
    }
}

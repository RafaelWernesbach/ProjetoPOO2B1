using Banco.model.contas;

namespace Banco.model.transacoes
{
    // A interface ITransacao define o contrato para diferentes tipos de transações.
    // Classes que implementam esta interface devem fornecer informações sobre a transação
    // e implementar o método Efetuar.
    public interface ITransacao
    {
        // Propriedade para obter a data da transação
        DateTime Data { get; }

        // Propriedade para obter o valor da transação
        double Valor { get; }

        // Propriedade para obter a conta de origem
        Conta ContaOrigem { get; }

        // Propriedade para obter a conta de destino
        Conta ContaDestino { get; }

        // Propriedade para obter o tipo da transação
        string Tipo { get; }

        // Método que deve ser implementado para efetuar a transação
        void Efetuar();
    }
}

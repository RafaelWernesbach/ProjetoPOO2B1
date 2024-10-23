using System;

namespace Banco.model.clientes
{
    // A classe Cliente representa um cliente do banco, contendo informações pessoais relevantes.
    public class Cliente
    {
        // Nome do cliente
        public string Nome { get; private set; }

        // Documento de identificação do cliente
        public string Documento { get; private set; }

        // Tipo do documento (ex: CPF, RG)
        public string TipoDocumento { get; private set; }

        // Construtor que inicializa as propriedades do cliente
        public Cliente(string nome, string documento, string tipoDocumento)
        {
            Nome = nome; // Inicializa o nome do cliente
            Documento = documento; // Inicializa o documento do cliente
            TipoDocumento = tipoDocumento; // Inicializa o tipo do documento
        }
    }
}

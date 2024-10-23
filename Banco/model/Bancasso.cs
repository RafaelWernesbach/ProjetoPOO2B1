using System;
using Banco.model.clientes; // Importa o namespace para gerenciar clientes
using Banco.model.transacoes; // Importa o namespace para gerenciar transações
using Banco.model.contas; // Importa o namespace para gerenciar contas

namespace Banco.model
{
    // A classe Bancasso atua como o sistema bancário principal, gerenciando clientes, contas e transações.
    public class Bancasso
    {
        private GerenciadorDeClientes GerenciadorClientes { get; set; } // Gerenciador de clientes
        private GerenciadorDeContas GerenciadorContas { get; set; } // Gerenciador de contas
        private GerenciadorDeTransacoes GerenciadorTransacoes { get; set; } // Gerenciador de transações

        // Construtor que inicializa os gerenciadores de clientes, contas e transações
        public Bancasso()
        {
            GerenciadorClientes = new GerenciadorDeClientes(); // Cria uma nova instância do gerenciador de clientes
            GerenciadorContas = new GerenciadorDeContas(); // Cria uma nova instância do gerenciador de contas
            GerenciadorTransacoes = new GerenciadorDeTransacoes(); // Cria uma nova instância do gerenciador de transações
        }

        /// <summary>
        /// Obtém o gerenciador de clientes.
        /// </summary>
        public GerenciadorDeClientes GetGerenciadorDeClientes()
        {
            return GerenciadorClientes;
        }

        /// <summary>
        /// Obtém o gerenciador de contas.
        /// </summary>
        public GerenciadorDeContas GetGerenciadorDeContas()
        {
            return GerenciadorContas;
        }

        /// <summary>
        /// Obtém o gerenciador de transações.
        /// </summary>
        public GerenciadorDeTransacoes GetGerenciadorDeTransacoes()
        {
            return GerenciadorTransacoes;
        }
    }
}

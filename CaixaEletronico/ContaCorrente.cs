using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    public class ContaCorrente : IServicoRemoto
    {
        public decimal Saldo { get; set; }
        public string Conta { get; set; }

        //deve ser chamado apenas no caso de ser feito algum saque ou depósito com sucesso
        public string PersistirConta(ContaCorrente conta)
        {
            this.Conta = conta.Conta;
            this.Saldo = conta.Saldo;
            return "Conta alterada!";
        }

        public ContaCorrente RecuperarConta(string conta)
        {
            if (Conta == conta) return this;

            throw new Exception("Conta desconhecida");
        }
        /* 

        ContaCorrente que possui as informações da conta necessárias para executar as funcionalidades do CaixaEletronico. 
        Essa classe faz parte da implementação e deve ser definida durante a sessão de TDD.
        
        */
    }
}

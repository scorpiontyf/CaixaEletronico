using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    public class CaixaEletronico
    {
        private readonly IServicoRemoto servico;
        private readonly IHardware hardware;
        private ContaCorrente conta;

        public CaixaEletronico(IServicoRemoto servico, IHardware hardware)
        {
            this.servico = servico;
            this.hardware = hardware;
        }

        public string Logar()
        {
            try
            {
                var numeroConta = hardware.PegarNumeroDaContaCartao();
                conta = servico.RecuperarConta(numeroConta);
                return "Usuário Autenticado";
            }
            catch
            {
                return "Não foi possível autenticar o usuário";
            }
        }

        public string Sacar(decimal valor)
        {
            if (conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                hardware.EntregarDinheiro();
                servico.PersistirConta(conta);
                return "Retire seu dinheiro";
            }
            return "Saldo insuficiente";
        }

        public string Depositar()
        {
            try
            {
                hardware.LerEnvelope();
                conta.Saldo += 100; // valor de exemplo
                servico.PersistirConta(conta);
                return "Depósito recebido com sucesso";
            }
            catch
            {
                return "Falha ao receber envelope";
            }
        }

        public string Saldo()
        {
            return $"O saldo é R${conta.Saldo:0.00}";
        }
    }

}

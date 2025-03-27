using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    public interface IHardware
    {
        /* 
         Existe uma interface chamada Hardware que possui os métodos pegarNumeroDaContaCartao() 
        para ler o número da conta do cartão para o login (retorna uma String com o número da conta),
        entregarDinheiro() que entrega o dinheiro no caso do saque (retorna void) e lerEnvelope() 
        que recebe o envelope com dinheiro na operação de depósito (retorna void).
        Não tem nenhuma implementação disponível da interface Hardware e deve ser utilizado 
        um Mock Object para ela durante os testes.
         */
        public ContaCorrente PegarNumeroDaContaCartao(string conta);

        public void EntregarDinheiro(decimal valor);
        public void LerEnvelope(decimal valor);
    }
}

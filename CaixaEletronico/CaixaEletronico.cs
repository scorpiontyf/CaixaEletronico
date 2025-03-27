using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    public class CaixaEletronico
    {
        public ContaCorrente Conta { get; set; } = new ContaCorrente();
        /*
          logar(), sacar(), depositar() e saldo() e todas retornam uma String com a mensagem que será exibida na tela do caixa eletrônico.
         */
        //Ao executar o método login(), e a execução for com sucesso, deve retornar a mensagem "Usuário Autenticado".
        //Caso falhe, deve retornar "Não foi possível autenticar o usuário"
        public string Logar(string conta)
        {
            try
            {
                if (conta != this.Conta.Conta) throw new Exception();
                
                return "Usuário Autenticado";
            }
            catch (Exception ex) 
            {
                throw new Exception("Não foi possível autenticar o usuário");
            }
        }
        //Ao executar o método sacar(), e a execução for com sucesso, deve retornar a mensagem "Retire seu dinheiro".
        //Se o valor sacado for maior que o saldo da conta, a classe CaixaEletronico deve retornar uma String dizendo "Saldo insuficiente".
        public string Sacar(decimal valor)
        {
            if(this.Conta.Saldo > valor)
            {
                return "Retire seu dinheiro!";
            }
            return "Saldo insuficiente.";
        }

        //Ao executar o método depositar(), e a execução for com sucesso, deve retornar a mensagem "Depósito recebido com sucesso"
        public string Depositar(decimal valor)
        {
            if(valor > 0)
            {
                this.Conta.Saldo += valor;
                return "Depósito recebido com sucesso!";
            }

            return "Valor inválido!";
        }
        //Ao executar o método saldo(), a mensagem retornada deve ser "O saldo é R$xx,xx" com o valor do saldo.
        public string Saldo()
        {
            return $"O saldo é de R${Conta.Saldo}";
        }

        public ContaCorrente PegarNumeroDaContaCartao(string conta)
        {
            if (conta == this.Conta.Conta)
            {
                return this.Conta;
            }

            return new ContaCorrente();
        }

        public void EntregarDinheiro(decimal valor)
        {
             Console.WriteLine("Dinheiro entregue");
        }

        public void LerEnvelope(decimal valor)
        {
            Console.WriteLine("Envelope recebido");
        }

        public string PegarNumeroDaContaCartao(int numeroConta)
        {
            return this.Conta.Conta;
        }
    }
}

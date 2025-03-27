using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    public interface IServicoRemoto
    {
        public ContaCorrente RecuperarConta(string conta);
        //deve ser chamado apenas no caso de ser feito algum saque ou depósito com sucesso
        public string PersistirConta(ContaCorrente conta);
    }
}

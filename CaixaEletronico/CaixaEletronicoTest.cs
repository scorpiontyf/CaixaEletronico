namespace CaixaEletronico
{
    public class CaixaEletronicoTest
    {
        ContaCorrente contaCorrente;
        CaixaEletronico caixaEletronico;
        public CaixaEletronicoTest()
        {
            contaCorrente = new ContaCorrente
            {
                Conta = "123",
                Saldo = 200000
            };
            caixaEletronico = new CaixaEletronico
            {
                Conta = contaCorrente,
            };
        }

        [Fact]
        public void LogarComSucesso()
        {
            var login = caixaEletronico.Logar("123");
            Assert.Equal("Usuário Autenticado", login);
        }
        
        [Fact]
        public void LogarComFalha()
        {
            var ex = Assert.Throws<Exception>(() => caixaEletronico.Logar("321"));
            Assert.Equal("Não foi possível autenticar o usuário", ex.Message);
        }

        [Fact]
        public void SacarComSucesso()
        {
            Assert.Equal("Retire seu dinheiro!", caixaEletronico.Sacar(1000));
        }
        
        [Fact]
        public void SacarComFalha()
        {
            Assert.Equal("Saldo insuficiente.", caixaEletronico.Sacar(1000000));
        }

        [Fact]
        public void DepositarComSucesso()
        {
            var saldoAntigo = caixaEletronico.Conta.Saldo;
            Assert.Equal("Depósito recebido com sucesso!", caixaEletronico.Depositar(1000));
            Assert.True(caixaEletronico.Conta.Saldo == saldoAntigo + 1000);
        }

        [Fact]
        public void DepositarComFalha()
        {
            var saldoAntigo = caixaEletronico.Conta.Saldo;
            Assert.Equal("Valor inválido!", caixaEletronico.Depositar(-10));
            Assert.True(caixaEletronico.Conta.Saldo != saldoAntigo - 10);
        }
    }
}
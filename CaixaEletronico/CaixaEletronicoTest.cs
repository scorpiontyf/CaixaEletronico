using Moq;
using Xunit;

namespace CaixaEletronico.Tests
{
    public class CaixaEletronicoTest
    {
        private readonly Mock<IServicoRemoto> servicoMock;
        private readonly Mock<IHardware> hardwareMock;
        private readonly CaixaEletronico caixa;
        private readonly ContaCorrente contaMock;

        public CaixaEletronicoTest()
        {
            servicoMock = new Mock<IServicoRemoto>();
            hardwareMock = new Mock<IHardware>();

            contaMock = new ContaCorrente
            {
                Conta = "123",
                Saldo = 200
            };

            caixa = new CaixaEletronico(servicoMock.Object, hardwareMock.Object);
        }

        [Fact]
        public void LogarComSucesso()
        {
            hardwareMock.Setup(h => h.PegarNumeroDaContaCartao()).Returns("123");
            servicoMock.Setup(s => s.RecuperarConta("123")).Returns(contaMock);

            var resultado = caixa.Logar();

            Assert.Equal("Usuário Autenticado", resultado);
        }

        [Fact]
        public void LogarComFalha()
        {
            hardwareMock.Setup(h => h.PegarNumeroDaContaCartao()).Throws(new Exception());

            var resultado = caixa.Logar();

            Assert.Equal("Não foi possível autenticar o usuário", resultado);
        }

        [Fact]
        public void SacarComSucesso()
        {
            LogarComSucesso();

            var resultado = caixa.Sacar(100);

            Assert.Equal("Retire seu dinheiro", resultado);
            servicoMock.Verify(s => s.PersistirConta(It.Is<ContaCorrente>(c => c.Saldo == 100)), Times.Once);
            hardwareMock.Verify(h => h.EntregarDinheiro(), Times.Once);
        }

        [Fact]
        public void SacarComFalha_PorSaldoInsuficiente()
        {
            LogarComSucesso();

            var resultado = caixa.Sacar(500);

            Assert.Equal("Saldo insuficiente", resultado);
            servicoMock.Verify(s => s.PersistirConta(It.IsAny<ContaCorrente>()), Times.Never);
            hardwareMock.Verify(h => h.EntregarDinheiro(), Times.Never);
        }

        [Fact]
        public void DepositarComSucesso()
        {
            LogarComSucesso();
            hardwareMock.Setup(h => h.LerEnvelope());

            var resultado = caixa.Depositar();

            Assert.Equal("Depósito recebido com sucesso", resultado);
            servicoMock.Verify(s => s.PersistirConta(It.IsAny<ContaCorrente>()), Times.Once);
        }

        [Fact]
        public void DepositarComFalha()
        {
            LogarComSucesso();
            hardwareMock.Setup(h => h.LerEnvelope()).Throws(new Exception());

            var resultado = caixa.Depositar();

            Assert.Equal("Falha ao receber envelope", resultado);
            servicoMock.Verify(s => s.PersistirConta(It.IsAny<ContaCorrente>()), Times.Never);
        }

        [Fact]
        public void DeveRetornarSaldoFormatado()
        {
            LogarComSucesso();

            var resultado = caixa.Saldo();

            Assert.Equal("O saldo é R$200,00", resultado);
        }
    }
}

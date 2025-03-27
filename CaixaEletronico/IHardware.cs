namespace CaixaEletronico
{
    public interface IHardware
    {
        // Retorna o número da conta a partir do cartão inserido
        string PegarNumeroDaContaCartao();

        // Entrega o dinheiro ao cliente no caso de saque
        void EntregarDinheiro();

        // Recebe o envelope de depósito
        void LerEnvelope();
    }
}

namespace CaixaEletronico
{
    public interface IServicoRemoto
    {
        // Recupera a conta a partir do número da conta
        ContaCorrente RecuperarConta(string conta);

        // Persiste alterações na conta após saque ou depósito
        string PersistirConta(ContaCorrente conta);
    }
}

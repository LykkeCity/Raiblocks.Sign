namespace Lykke.Service.RaiblocksSign.Models
{
    public class SignResponse
    {
        public SignResponse(string transactionData) => SignedTransaction = transactionData;

        public string SignedTransaction { get; }
    }
}

namespace Lykke.Service.RaiblocksSign.Models
{
    public class NewWalletResponse
    {
        public NewWalletResponse((string key, string address) data) => (PrivateKey, PublicAddress) = data;
        public string PrivateKey { get; set; }

        public string PublicAddress { get; set; }
    }
}

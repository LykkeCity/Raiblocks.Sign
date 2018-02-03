namespace Lykke.Service.RaiblocksSign.SignService.Core.Services
{
    public interface IWalletService
    {
        (string key, string address) CreateWallet();
    }
}

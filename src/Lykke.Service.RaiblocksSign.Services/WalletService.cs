using Lykke.Service.RaiblocksSign.SignService.Core.Services;
using System.Runtime.InteropServices;

namespace Lykke.Service.RaiblocksSign.Services
{
    public class WalletService : IWalletService
    {

        [DllImport("libsign_service.dll")]
        public static extern string key_create();

        public (string key, string address) CreateWallet()
        {
            var key = key_create().Split(':');

            return (key[0], key[1]);
        }
    }
}

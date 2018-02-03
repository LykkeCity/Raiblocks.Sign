using Lykke.Service.RaiblocksSign.Core.Domain;

namespace Lykke.Service.RaiblocksSign.SignService.Core.Services
{
    public interface ITransactionService
    {
        IRaiBlock Sign(string key, IRaiBlock raiBlock);
    }
}

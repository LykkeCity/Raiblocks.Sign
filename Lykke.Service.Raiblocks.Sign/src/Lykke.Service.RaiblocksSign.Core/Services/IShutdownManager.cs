using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksSign.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
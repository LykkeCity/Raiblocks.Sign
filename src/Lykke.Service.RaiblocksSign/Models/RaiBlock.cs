using Lykke.Service.RaiblocksSign.Core.Domain;

namespace Lykke.Service.RaiblocksSign.Models
{
    public class RaiBlock:IRaiBlock
    {
        public string type { get; set; }
        public string account { get; set; }
        public string representative { get; set; }
        public string link { get; set; }
        public string balance { get; set; }
        public string previous { get; set; }
        public string work { get; set; }

        public string signature { get; set; }
    }
}

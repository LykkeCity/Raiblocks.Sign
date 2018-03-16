using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.RaiblocksSign.Core.Domain;

namespace Lykke.Service.RaiblocksSign.Models
{
    public class RaiBlock:IRaiBlock
    {
        public string type { get; set; }
        public string account { get; set; }
        public string destination { get; set; }
        public string source { get; set; }
        public string amount { get; set; }
        public string work { get; set; }
        public string previous { get; set; }
        public string balance { get; set; }
        public string signature { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.RaiblocksSign.Models
{
    public class NewWalletResponse
    {
        public string PrivateKey { get; set; }

        public string PublicAddress { get; set; }
    }
}

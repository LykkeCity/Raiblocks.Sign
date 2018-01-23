using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.RaiblocksSign.Models
{
    public class SignRequest
    {
        public string[] PrivateKeys { get; set; }

        public string TransactionContext { get; set; }
    }
}

using Lykke.Service.RaiblocksSign.Core.Domain;
using Lykke.Service.RaiblocksSign.Core.Services;
using Lykke.Service.RaiblocksSign.SignService.Core.Services;

using System.Runtime.InteropServices;

namespace Lykke.Service.RaiblocksSign.Services
{
    public class TransactionService : ITransactionService
    {
        [DllImport("libsign_service")]
        public static extern string block_create_c(
            string type_text,
            string account_text,
            string representative_text,
            string link_text,
            string balance_text,
            string previous_text,
            string work_text,
            string key_text,
            ref int errorCode
        );

        public string Sign(string key, IRaiBlock raiBlock)
        {
            int err = 0;
            var result = block_create_c(
                raiBlock.type,
                raiBlock.account,
                raiBlock.representative,
                raiBlock.link,
                raiBlock.balance,
                raiBlock.previous,
                raiBlock.work,
                key,
                ref err);

            if (err != 0)
            {
                throw new RaiBlocksSignException(result);
            }
            return result;
        }

    }
}

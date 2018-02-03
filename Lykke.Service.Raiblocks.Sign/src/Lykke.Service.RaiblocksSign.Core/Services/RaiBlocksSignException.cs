using System;

namespace Lykke.Service.RaiblocksSign.Core.Services
{
    public class RaiBlocksSignException : Exception
    {
        const int result_ok = 0;
        const int result_err_privateKey_or_account = 1;//"Private key or local wallet and account required"
        const int result_err_invalid_block_type = 2;//"Invalid block type"
        const int result_err_no_enough_dest_fields = 3;//"Destination account, previous hash, current balance and amount required"
        const int result_err_account_and_source_hash_required = 4;//"Representative account and source hash required"
        const int result_err_hash_and_source_required = 5;//"Previous hash and source hash required"
        const int result_err_insufficient_balance = 6;//"Insufficient balance"
        const int result_err_need_work = 7;//"Need work"
        const int result_err_unknown = 100;//"Unknown error"

        private readonly int _errorCode;

        public RaiBlocksSignException(int errorCode)
        {
            _errorCode = errorCode;
        }

        public override string Message
        {
            get
            {
                switch (_errorCode)
                {
                    case result_err_privateKey_or_account:
                        return "Private key or local wallet and account required";
                    case result_err_invalid_block_type:
                        return "Invalid block type";
                    case result_err_no_enough_dest_fields:
                        return "Destination account, previous hash, current balance and amount required";
                    case result_err_account_and_source_hash_required:
                        return "Representative account and source hash required";
                    case result_err_hash_and_source_required:
                        return "Previous hash and source hash required";
                    case result_err_insufficient_balance:
                        return "Insufficient balance";
                    case result_err_need_work:
                        return "Need work";
                    case result_err_unknown:
                        return "Unknown error";
                }

                return "Unexpected sign error code";
            }
        }
    }
}

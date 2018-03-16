using System;
using Common.Log;

namespace Lykke.Service.RaiblocksSign.Client
{
    public class RaiblocksSignClient : IRaiblocksSignClient, IDisposable
    {
        private readonly ILog _log;

        public RaiblocksSignClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}

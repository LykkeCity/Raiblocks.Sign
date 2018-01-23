using Lykke.Service.RaiblocksSign.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksSign.Controllers
{
    [Route("api/[controller]")]
    public class WalletsController : Controller
    {
        /// <summary>
        /// Create a new wallet (address) in the blockchain
        /// </summary>
        /// <returns>New wallet (address)</returns>
        [HttpPost]
        [SwaggerOperation("CreateNewWallet")]
        [ProducesResponseType(typeof(NewWalletResponse), (int)HttpStatusCode.OK)]
        public IActionResult CreateNewWallet()
        {
            throw new NotImplementedException();
        }
    }
}

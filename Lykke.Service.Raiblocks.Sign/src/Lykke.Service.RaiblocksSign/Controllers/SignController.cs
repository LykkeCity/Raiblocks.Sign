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
    public class SignController : Controller
    {
        /// <summary>
        /// Sign given transaction with the given private key
        /// </summary>
        /// <param name="signRequest">Sign request</param>
        /// <returns>Signed transaction</returns>
        [HttpPost]
        [SwaggerOperation("SignTransaction")]
        [ProducesResponseType(typeof(SignResponse), (int)HttpStatusCode.OK)]
        public IActionResult SignTransaction([FromBody] SignRequest signRequest)
        {
            throw new NotImplementedException();
        }
    }
}

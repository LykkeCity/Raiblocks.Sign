using Lykke.Service.RaiblocksSign.Core.Services;
using Lykke.Service.RaiblocksSign.Models;
using Lykke.Service.RaiblocksSign.SignService.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Lykke.Service.RaiblocksSign.Controllers
{
    [Route("api/[controller]")]
    public class SignController : Controller
    {
        readonly ITransactionService _transactionService;
        public SignController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        /// <summary>
        /// Sign given transaction with the given private key
        /// </summary>
        /// <param name="signRequest">Sign request</param>
        /// <returns>Signed transaction</returns>
        [HttpPost]
        [ProducesResponseType(typeof(SignResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public IActionResult SignTransaction([FromBody]SignRequest signRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.Create(ModelState));
            }
            var result = string.Empty;
            try
            {
                var signedBlock = _transactionService.Sign(signRequest.Key, signRequest.Block);
                result = JsonConvert.SerializeObject(signedBlock);
            }
            catch (RaiBlocksSignException rbse)
            {
                return BadRequest(rbse);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(new SignResponse(result));
        }

    }
}

using Common.Log;
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
        readonly ILog _logService;
        public SignController(ITransactionService transactionService, ILog logService)
        {
            _transactionService = transactionService;
            _logService = logService;
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
                _logService.WriteError("SignTransaction", "ModelState is invalid");
                return BadRequest(ErrorResponse.Create(ModelState));
            }
            var result = string.Empty;
            try
            {
                result = _transactionService.Sign(signRequest.Key, signRequest.Block);
            }
            catch (RaiBlocksSignException rbse)
            {
                _logService.WriteError("SignTransaction", "", rbse);
                return BadRequest(rbse);
            }
            catch (Exception e)
            {
                _logService.WriteError("SignTransaction", "", e);
                return BadRequest(e);
            }

            return Ok(new SignResponse(result));
        }

    }
}

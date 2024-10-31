using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaPagamentosSimplificada.Dtos;
using PlataformaPagamentosSimplificada.Models;
using PlataformaPagamentosSimplificada.Services.Transaction;

namespace PlataformaPagamentosSimplificada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionInterface _transactionInterface;

        public TransactionController(ITransactionInterface transactionInterface)
        {
            _transactionInterface = transactionInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<TransactionModel>>> Pay(PayDto pay)
        {
            var transaction = await _transactionInterface.Pay(pay);
            return Ok(transaction);
        }
    }
}

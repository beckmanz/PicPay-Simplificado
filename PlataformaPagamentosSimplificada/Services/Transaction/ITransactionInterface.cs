using Microsoft.EntityFrameworkCore;
using PlataformaPagamentosSimplificada.Dtos;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.Transaction;

public interface ITransactionInterface
{
    Task<ResponseModel<TransactionModel>> Pay(PayDto pay);
}
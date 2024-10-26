using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Dtos;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Services.Transaction;

public interface ITransactionInterface
{
    Task<ResponseModel<TransactionModel>> Pay(PayDto pay);
}
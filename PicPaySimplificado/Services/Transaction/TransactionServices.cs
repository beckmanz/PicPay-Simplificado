using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PicPaySimplificado.Data;
using PicPaySimplificado.Dtos;
using PicPaySimplificado.Enums;
using PicPaySimplificado.Models;
using PicPaySimplificado.Services.Authorizer;

namespace PicPaySimplificado.Services.Transaction;

public class TransactionServices : ITransactionInterface
{

    private readonly AppDbContext _context;
    private readonly IAuthorizerInterface _authorizerInterface;

    public TransactionServices(AppDbContext context, IAuthorizerInterface authorizerInterface)
    {
        _context = context;
        _authorizerInterface = authorizerInterface;
    }

    public async Task<ResponseModel<TransactionModel>> Pay(PayDto pay)
    {
        ResponseModel<TransactionModel> response = new ResponseModel<TransactionModel>();
        try
        {
            if (!await _authorizerInterface.Authorize())
            {
                response.Message = "Transação não autorizado pelo serviço autorizador, tente novamente mais tarde!";
                response.Status = false;
                return response;
            }
            var sender = await _context.Users.FirstOrDefaultAsync(u => u.Id == pay.Sender);
            var receiver = await _context.Users.FirstOrDefaultAsync(u => u.Id == pay.Receiver);
            
            if (sender.Balance < pay.Value)
            {
                response.Message = "O saldo do usuário é insuficiente para completar a transação!";
                response.Status = true;
                return response;
            }
            if (sender is null || receiver is null)
            {
                response.Message = "Usuário não encontrado!";
                response.Status = true;
                return response;
            }
            if(sender.UserType == UserType.Merchant)
            {
                response.Message = "Logistas não podem efetuar transferências, apenas receber!";
                response.Status = true;
                return response;
            }

            var debitar = sender.Balance - pay.Value;
            var creditar = receiver.Balance + pay.Value;

            sender.Balance = debitar;
            receiver.Balance = creditar;

            var transfer = new TransactionModel()
            {
                Amount = pay.Value,
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Sender = sender,
                Receiver = receiver
            };

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Update(sender);
                    _context.Update(receiver);
                    _context.Add(transfer);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    response.Message = ex.Message;
                    response.Status = false;
                    return response;
                }
            }

            response.Message = "Transação realizada com sucesso!!";
            response.Status = true;
            response.Data = transfer;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }
}
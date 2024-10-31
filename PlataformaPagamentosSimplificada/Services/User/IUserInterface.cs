using PlataformaPagamentosSimplificada.Dtos;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.User;

public interface IUserInterface
{
    Task<ResponseModel<UserModel>> Register(RegisterDto register);
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> Deposit(DepositDto deposit);
}
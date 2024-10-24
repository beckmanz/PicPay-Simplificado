using PicPaySimplificado.Dtos;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Services.User;

public interface IUserInterface
{
    Task<ResponseModel<UserModel>> Register(RegisterDto register);
}
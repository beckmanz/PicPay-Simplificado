using PicPaySimplificado.Models;

namespace PicPaySimplificado.Services.Authorizer;

public interface IAuthorizerInterface
{
    Task<bool> Authorize();
}
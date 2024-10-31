using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.Authorizer;

public interface IAuthorizerInterface
{
    Task<bool> Authorize();
}
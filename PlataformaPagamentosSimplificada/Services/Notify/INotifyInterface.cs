using NuGet.Protocol.Plugins;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.Notify;

public interface INotifyInterface
{
    Task Notify(UserModel Sender, UserModel Receiver);
}
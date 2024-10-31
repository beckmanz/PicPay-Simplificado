using NuGet.Protocol.Plugins;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Services.Notify;

public interface INotifyInterface
{
    Task Notify(UserModel Sender, UserModel Receiver);
}
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.Notify;

public class NotifyService : INotifyInterface
{
    public async Task Notify(UserModel Sender, UserModel Receiver)
    { 
        await Task.Delay(1000);
        Console.WriteLine($"{Sender.FirstName}, sua transferência foi realizada com sucesso!");
        Console.WriteLine($"{Receiver.FirstName}, uma nova transferência foi recebida!");
    }
}
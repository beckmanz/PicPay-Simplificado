namespace PlataformaPagamentosSimplificada.Models;

public class TransactionModel
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public UserModel Sender { get; set; }
    public UserModel Receiver { get; set; }
}
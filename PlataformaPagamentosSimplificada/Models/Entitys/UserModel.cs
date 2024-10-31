using PlataformaPagamentosSimplificada.Enums;

namespace PlataformaPagamentosSimplificada.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public int Password { get; set; }
    public decimal Balance { get; set; }
    public UserType UserType { get; set; }
}
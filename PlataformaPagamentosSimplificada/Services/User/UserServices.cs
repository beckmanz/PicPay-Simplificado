using Microsoft.EntityFrameworkCore;
using PlataformaPagamentosSimplificada.Data.Map;
using PlataformaPagamentosSimplificada.Data;
using PlataformaPagamentosSimplificada.Dtos;
using PlataformaPagamentosSimplificada.Models;

namespace PlataformaPagamentosSimplificada.Services.User;

public class UserServices : IUserInterface
{
    private readonly AppDbContext _context;

    public UserServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<UserModel>> Register(RegisterDto register)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var user = await _context.Users.AnyAsync(u => u.Document == register.Document || u.Email == register.Email);
            if (user)
            {
                response.Message = "Usuário já cadastrado!";
                response.Status = true;
                return response;
            }

            var newUser = new UserModel()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Document = register.Document,
                Email = register.Email,
                Password = register.Password,
                Balance = 0,
                UserType = register.UserType
            };

            _context.Add(newUser);
            await _context.SaveChangesAsync();

            response.Message = "Usuário cadastrado com sucesso!";
            response.Status = true;
            response.Data = newUser;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
        try
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
            {
                response.Message = "Não foi encontrado usuários na base de dados!";
                response.Status = true;
                return response;
            }

            response.Message = "Usuários coletados com sucesso!";
            response.Status = true;
            response.Data = users;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<UserModel>> Deposit(DepositDto deposit)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == deposit.Id);
            if (user == null)
            {
                response.Message = "Usuário não encontrado!";
                response.Status = true;
                return response;
            }
            if (deposit.value <= 0)
            {
                response.Message = "Valor do deposito invalido!";
                response.Status = true;
                return response;
            }
            
            var depositar = user.Balance + deposit.value;
            user.Balance = depositar;
            
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            
            response.Message = "Depósito realizado com sucesso!";
            response.Status = true;
            response.Data = user;
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
using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Data;
using PicPaySimplificado.Data.Map;
using PicPaySimplificado.Dtos;
using PicPaySimplificado.Models;

namespace PicPaySimplificado.Services.User;

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
                Balance = register.Balance,
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
}
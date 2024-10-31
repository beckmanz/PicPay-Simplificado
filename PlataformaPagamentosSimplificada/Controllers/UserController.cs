using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaPagamentosSimplificada.Dtos;
using PlataformaPagamentosSimplificada.Models;
using PlataformaPagamentosSimplificada.Services.User;

namespace PlataformaPagamentosSimplificada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<UserModel>>> Register(RegisterDto register)
        {
            var user = await _userInterface.Register(register);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> GetAllUsers()
        {
            var users = await _userInterface.GetAllUsers();
            return Ok(users);
        }
        
        [HttpPut]
        public async Task<ActionResult<ResponseModel<UserModel>>> Deposit(DepositDto deposit)
        {
            var user = await _userInterface.Deposit(deposit);
            return Ok(user);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Dtos;
using PicPaySimplificado.Models;
using PicPaySimplificado.Services.User;

namespace PicPaySimplificado.Controllers
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
    }
}

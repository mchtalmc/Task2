using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Authentication;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public LoginController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("userLogin")]
        [AllowAnonymous] //Login olmadan da ulasabilir.
        public async Task<UserLoginResponse> LoginUser([FromBody] UserLoginRequest request)
        {
            var result= await _authRepository.LoginUser(request);
            return result;
        }
    }
}

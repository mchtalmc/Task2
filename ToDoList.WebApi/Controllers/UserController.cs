using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Token kullanma sarti
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // FromBody
        // FromRoute, FromQuery



   
        [HttpGet("{id}/userId")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var value = await _userService.GetUserById(id);
            return Ok(value);
        }


        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var value = await _userService.UpdateUser(updateUserDto);
            return Ok();
        }


        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            await _userService.AddUser(createUserDto);
            return Ok();
        }


        [HttpDelete("removeuser")]
        public async Task<IActionResult> RemoveUser( int id)
        {
            var value = await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("/anyfilter")]
        public async Task<IActionResult> GetTaskAnyFilter([FromQuery]GetUserRequest userRequest)
        {
            var value = await _userService.GetUserAnyParemetrer(userRequest);
            return Ok(value);
        }











        //[HttpGet("{username}/username")]
        //public async Task<IActionResult> GetUserWithByUsername(string username)
        //{
        //    var value = await _userService.GetUserWithUserName(username);
        //    return Ok(value);
        //}


        //[HttpGet("{age}/age")]
        //public async Task<IActionResult> GetUserByAge(int age)
        //{
        //    var value = await _userService.GetUserByAge(age);
        //    return Ok(value);
        //}


        //[HttpGet("{email}/email")]
        //public async Task<IActionResult> GetUserByEmail(string email)
        //{
        //    var value = await _userService.GetUserByEmail(email);
        //    return Ok(value);
        //}


        //[HttpGet("{name}/name")]
        //public async Task<IActionResult> GetUserByName(string name)
        //{
        //    var value = await _userService.GetUserByName(name);
        //    return Ok(value);
        //}


        //[HttpGet("{userImageUrl}/userImageUrl")]
        //public async Task<IActionResult> GetUserWithUserImageUrl(string userImageUrl)
        //{
        //    var value = await _userService.GetUserByUserImageUrl(userImageUrl);
        //    return Ok(value);
        //}


       


      


        
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Dtos;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var value = await _userService.GetAll();

            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var value = await _userService.GetUserById(id);
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var value = await _userService.DeleteUser(id);
            return Ok(new BaseResponse<object> { IsSuccess = true, Message = $"{id}'li Kullanici Silindi" });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            var value=  await _userService.UpdateUser(updateUserDto);
            return Ok(new BaseResponse<object> { IsSuccess = true, Message = "Kullanici Guncellendi" });
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            await _userService.AddUser(createUserDto);
            return Ok(new BaseResponse<object> { IsSuccess=true, Message="Kullanici Kaydedildi"});
        }




    }
}

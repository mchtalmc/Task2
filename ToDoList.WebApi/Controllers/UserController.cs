using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            await _userService.AddUser(createUserDto);
            return Ok(true);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var value= await _userService.GetUserById(id);
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id) // IGenericRepo'da entity alip onu sil , manager'da id ile ona ulasip sil. 
        {
            
             await _userService.DeleteUser(id);
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUser(updateUserDto);
            return Ok(true);
        }

      
       







    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos.TaskDto;
using TodoList.Core.Dtos.UserDtos;
using TodoList.Core.Entities;
using ToDoList.BussinessLayer.Abstract;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.BussinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(CreateUserDto createUserDto)
        {
            await _userDal.Add(_mapper.Map<User>(createUserDto));
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var value = await _userDal.TGet(id);
            await _userDal.Remove(value);
            return true;
        }

        public async Task<List<ResultUserDto>> GetAll()
        {
            var entity = await _userDal.GetList();
            var value = _mapper.Map<List<ResultUserDto>>(entity);
            return value;

        }

        public async Task<ResultUserDto> GetUserById(int id)
        {
            var value = await _userDal.TGet(id);
            return _mapper.Map<ResultUserDto>(value);
        }

        public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
           await  _userDal.Update(_mapper.Map<User>(updateUserDto));
            return true;
        }
    }
}

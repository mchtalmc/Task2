using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Dtos;
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

        public async Task<BaseResponse<object>> AddUser(CreateUserDto createUserDto)
        {
            await _userDal.Add(_mapper.Map<User>(createUserDto));
            return new BaseResponse<object> { IsSuccess=true, Message="Kayit Basarili" };
        }

        public async Task<BaseResponse<object>> DeleteUser(int id)
        {
           var value= await _userDal.TGet(id);
           bool isDelete= await _userDal.Remove(value);
            return new BaseResponse<object> { Message = $"{id} Kullanici silindi", IsSuccess = isDelete };
        }

        public async Task<BaseResponse<List<ResultUserDto>>> GetAll()
        {
            var value = await _userDal.GetList();
            var response = _mapper.Map<List<ResultUserDto>>(value);
            return new BaseResponse<List<ResultUserDto>> { IsSuccess=true, Message="Tum Kullanicilar", Data=response };
        }

        public async Task<BaseResponse<ResultUserDto>> GetUserById(int id)
        {
            var value = await _userDal.TGet(id);
            var response= _mapper.Map<ResultUserDto>(value);
            return new BaseResponse<ResultUserDto> { IsSuccess = true, Message = $"{id}'li Kullanici" , Data=response};
        }

        public async Task<BaseResponse<object>> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userDal.Update(_mapper.Map<User>(updateUserDto));
            return new BaseResponse<object> { IsSuccess = true, Message = "Guncelleme Basarili" };
        }
    }
}

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
using ToDoList.BussinessLayer.Validation.UserValidation;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.BussinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userDal;
        private readonly IMapper _mapper;
        private readonly UserValidationRules _rules;

        public UserManager(IUserRepository userDal, IMapper mapper, UserValidationRules rules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<BaseResponse<object>> AddUser(CreateUserDto createUserDto)
        {
            if(_rules.CheckEmail(createUserDto.Email))
            {
                return new BaseResponse<object> { Message = "Bu Email ile kayit yapilmis", IsSuccess = false };
            }
            if (_rules.CheckUsername(createUserDto.Username))
            {
                return new BaseResponse<object> { Message = "Bu Username ile kayit yapilmis", IsSuccess = false };
            }
            if (_rules.CheckUserImageUrl(createUserDto.UserİmageUrl))
            {
                return new BaseResponse<object> { Message = "Bu Image ile kayit yapilmis", IsSuccess = false };
            }
           
            await _userDal.Add(_mapper.Map<User>(createUserDto));
            return new BaseResponse<object> { Message = "Kayit Basarili" };
        }

        public async Task<BaseResponse<object>> DeleteUser(int id)
        {
            var value = await _userDal.TGet(id);
            if (value == null)
                return new BaseResponse<object> { IsSuccess = false, Message = "Kullanici Bulunamadi" };

            bool isDelete = await _userDal.Remove(value);
            return new BaseResponse<object> { Message = $"{id} Kullanici silindi", IsSuccess = isDelete };
        }


        public async Task<BaseResponse<object>> UpdateUser(UpdateUserDto updateUserDto)
        {
            if (_rules.CheckEmail(updateUserDto.Email))
            {
                return new BaseResponse<object> { Message = "Bu Email ile kayit yapilmis", IsSuccess = false };
            }
            if (_rules.CheckUsername(updateUserDto.Username))
            {
                return new BaseResponse<object> { Message = "Bu Username ile kayit yapilmis", IsSuccess = false };
            }
            if (_rules.CheckUserImageUrl(updateUserDto.UserİmageUrl))
            {
                return new BaseResponse<object> { Message = "Bu Image ile kayit yapilmis", IsSuccess = false };
            }
            await _userDal.Update(_mapper.Map<User>(updateUserDto));
            return new BaseResponse<object> { IsSuccess = true, Message = "Guncelleme Basarili" };
        }
       

        public async Task<BaseResponse<ResultUserDto>> GetUserById(int id) // Bu method
        {

            var value = await _userDal.TGet(id);
            if (value == null)
            {
                return new BaseResponse<ResultUserDto> { IsSuccess = false, Message = "Kullanici Bulunamadi" };
            }
            var response = _mapper.Map<ResultUserDto>(value);
            return new BaseResponse<ResultUserDto> { Message = $"{id}'li Kullanici", Data = response };
        }

        public async Task<BaseResponse<List<GetUserRequestDto>>> GetUserAnyParemetrer(GetUserRequest request)
        {
            
            var value = await _userDal.GetUserByAnyParametrer(request);

            if (value != null && value.Any())
            {
                var response = _mapper.Map<List<GetUserRequestDto>>(value);
                return new BaseResponse<List<GetUserRequestDto>>
                {
                    Data = response,
                    IsSuccess = true,
                    Message = "Filtrelenen Kullanıcılar"
                };
            }

            return new BaseResponse<List<GetUserRequestDto>>
            {
                IsSuccess = false,
                Message = "Filtreleme Sonucunda Kullanıcı Bulunamadı"
            };
        }



        //public async Task<BaseResponse<List<ResultUserDto>>> GetUserByName(string? name)
        //{

        //    var value= await _userDal.GetUserByName(name);
        //    var response= _mapper.Map<List<ResultUserDto>>(value);
        //    return new BaseResponse<List<ResultUserDto>> { Message = $"{name}'li Kullanicilar", Data = response };
        //}

        //public async Task<BaseResponse<List<ResultUserDto>>> GetUserByUserImageUrl(string? userImageUrl)
        //{
        //    var value= await _userDal.GetUserByUserImageUrl(userImageUrl);
        //    var response = _mapper.Map<List<ResultUserDto>>(value);
        //    return new BaseResponse<List<ResultUserDto>> { Message= $"{userImageUrl}'li Kullanicilar", Data= response };
        //}

        //public Task<BaseResponse<List<ResultUserDto>>> GetUserByUsername(string? userName)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<BaseResponse<List<ResultUserDto>>> GetUserWithUserName(string? username)
        //{
        //    var values = await _userDal.GetUserByName(username);
        //    if (string.IsNullOrEmpty(username) && values ==null)
        //    {
        //        return new BaseResponse<List<ResultUserDto>> { IsSuccess = false, Data = null, Message = $"{username}'e ati Kullanici bulunamadi" };
        //    }

        //    var response = _mapper.Map<List<ResultUserDto>>(values);
        //    return new BaseResponse<List<ResultUserDto>> { Data = response, Message = $"{username}'e Sahip Kullanicilar" };
        //}
        //public async Task<BaseResponse<List<ResultUserDto>>> GetUserByAge(int? id)
        //{
        //    var value = await _userDal.GetUserByAge(id);
        //    var response = _mapper.Map<List<ResultUserDto>>(value);
        //    return new BaseResponse<List<ResultUserDto>> { Message = $"{id}' Yasinda ki User'lar", Data = response };
        //}

        //public async Task<BaseResponse<ResultUserDto>> GetUserByEmail(string? email)
        //{
        //    var value = await _userDal.GetUserByEmail(email);
        //    var response = _mapper.Map<ResultUserDto>(value);
        //    return new BaseResponse<ResultUserDto> { Message = $"{email}' li Kullanici", Data = response };
        //}

    }
}

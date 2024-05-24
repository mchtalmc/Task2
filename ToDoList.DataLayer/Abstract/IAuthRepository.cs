﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Authentication;

namespace ToDoList.DataLayer.Abstract
{
    public interface IAuthRepository
    {
        public Task<UserLoginResponse> LoginUser(UserLoginRequest request);
    }
}

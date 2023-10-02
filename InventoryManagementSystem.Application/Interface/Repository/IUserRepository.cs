﻿using InventoryManagementSystem.Application.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(UserRegistrationModel user);
        Task<bool> LoginUser(LoginUserModel user);
        Task<string> CreateToken();
    }
}
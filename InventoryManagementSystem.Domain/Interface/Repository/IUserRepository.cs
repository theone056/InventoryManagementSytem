using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(UserRegistrationModel user);
        Task<bool> LoginUser(LoginUserModel user);

        Task<User> FindUserByName(string userName);
        Task<IList<string>> GetAllRoles(User user);
    }
}

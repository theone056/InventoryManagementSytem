using AutoMapper;
using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private User? _user;

        public UserRepository(UserManager<User> userManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;

        }

        public async Task<bool> LoginUser(LoginUserModel user)
        {
            _user = await _userManager.FindByNameAsync(user.UserName);
            if (_user != null)
            {
                var result = await _userManager.CheckPasswordAsync(_user, user.Password);
                return result;
            }
            return false;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationModel user)
        {
            var userResult = _mapper.Map<User>(user);
            userResult.DateCreated = DateTime.UtcNow;
            var result = await _userManager.CreateAsync(_user,user.Password);
            return result;
        }
    }
}

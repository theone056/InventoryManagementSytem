using AutoMapper;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using InventoryManagementSystem.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private User? _user;
        private readonly IMSDbContext _dbContext;

        public UserRepository(UserManager<User> userManager, IMapper mapper, IConfiguration config, IMSDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
            _dbContext = context;
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

        public async Task<User> FindUserByName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
     
        }

        public async Task<IList<string>> GetAllRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}

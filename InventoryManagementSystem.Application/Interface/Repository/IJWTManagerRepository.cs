using InventoryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interface.Repository
{
    public interface IJWTManagerRepository
    {
        Task<Tokens> CreateToken(string userName);
        Task<Tokens> CreateRefreshToken(string userName);
        Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    }
}

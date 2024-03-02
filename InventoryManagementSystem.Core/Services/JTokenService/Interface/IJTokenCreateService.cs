using InventoryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core.Services.JTokenService.Interface
{
    public interface IJTokenCreateService
    {
        Task<Tokens> CreateToken(string userName);
        Task<Tokens> CreateRefreshToken(string userName);
    }
}

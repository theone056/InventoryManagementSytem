using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Application.Services.JTokenService.Interface;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services.JTokenService
{
    public class JTokenCreateService : IJTokenCreateService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public JTokenCreateService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        public async Task<Tokens> CreateRefreshToken(string userName)
        {
            return await CreateToken(userName);
        }
        public async Task<Tokens> CreateToken(string userName)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(userName);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            return new Tokens()
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                Refresh_Token = refreshToken
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _config.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }





        private async Task<List<Claim>> GetClaims(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };
            var _user = await _userRepository.FindUserByName(userName);
            var roles = await _userRepository.GetAllRoles(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}

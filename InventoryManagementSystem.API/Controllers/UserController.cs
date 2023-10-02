using InventoryManagementSystem.Application.Interface.Repository;
using InventoryManagementSystem.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationModel user)
        {
            if(ModelState.IsValid)
            {
                var userResult = await _user.RegisterUser(user);
                if(userResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, userResult);
                }
            }
            var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            return StatusCode(StatusCodes.Status400BadRequest, errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserModel user)
        {
            if(ModelState.IsValid)
            {
                var result = await _user.LoginUser(user);
                if(result)
                {
                    return Ok(new { Token = await _user.CreateToken() });
                }
            }

            return Unauthorized();
        }
    }
}

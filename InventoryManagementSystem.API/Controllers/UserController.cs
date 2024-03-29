﻿using AutoMapper;
using InventoryManagementSystem.Core.Domain.Entities;
using InventoryManagementSystem.Core.Domain.Interface.Repository;
using InventoryManagementSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IUserRepository user, IMapper mapper)
        {
            _user = user;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationModel user)
        {
            if(ModelState.IsValid)
            {
                var userResult = await _user.RegisterUser(user);

                if(userResult.Succeeded)
                {
                    //Uncomment if we will use email confirmation

                    //var userMap = _mapper.Map<User>(user);
                    //var token = await _userManager.GenerateEmailConfirmationTokenAsync(userMap);
                    //var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme, "");
                    //EmailHelper emailHelper = new EmailHelper();
                    //bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

                    //if (emailResponse)
                    //    return RedirectToAction("Index");
                    //else
                    //{
                    //    // log email failed 
                    //}

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

        //[HttpPost("Login")]
        //public async Task<IActionResult> LoginUser([FromBody] LoginUserModel user)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var result = await _user.LoginUser(user);
        //        if(result)
        //        {
        //            //return Ok();
        //            return Ok(new { Token = await _jwtManager.CreateToken(user.UserName) });
        //        }
        //    }

        //    return Unauthorized();
        //}
    }
}

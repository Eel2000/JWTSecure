using JWTSecure.Models;
using JWTSecure.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTSecure.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //Post: api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Account([FromBody] AppUser user)
        {
            try
            {
                var result = await _authService.Register(user.UserName, user.EmailAdress, user.Password);

                return Ok($"User Created With password! => {result}");
            }
            catch (Exception e)
            {
                return BadRequest("Faild to create User with Password =>" + e.Message);
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email,string password)
        {
            try
            {
                var result = await _authService.Login(email, password);

                return Ok($"User Log In Successfully => {result}");
            }
            catch (Exception e)
            {
                return BadRequest($"Fail to Login => {e.Message}");
            }
        }
    }
}

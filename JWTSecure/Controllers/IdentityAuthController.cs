using JWTSecure.Services.interfaces;
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
    public class IdentityAuthController : Controller
    {
        private readonly IIdentityAuthService _identityAuth;

        public IdentityAuthController(IIdentityAuthService identityAuth)
        {
            _identityAuth = identityAuth;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] string usernam,string email, string password)
        {
            try
            {
                var result = await _identityAuth.SignUp(usernam, email, password);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Error => {e.Message}");
            }
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] string username,string password)
        {
            try
            {
                var result = await _identityAuth.SignIn(username, password);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Error => {e.Message}");
                throw;
            }
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                var result = await _identityAuth.Logout();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Error => {e.Message}");
            }
        }
    }
}

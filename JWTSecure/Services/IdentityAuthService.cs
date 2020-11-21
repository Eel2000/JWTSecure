using JWTSecure.Context;
using JWTSecure.Models;
using JWTSecure.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTSecure.Services
{
    public class IdentityAuthService : IIdentityAuthService
    {
        private readonly JWTDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<JwtUser> _userManager;
        private readonly ILogger<IdentityAuthService> _logger;
        private readonly SignInManager<JwtUser> _signInManager;

        public IdentityAuthService(JWTDbContext context, UserManager<JwtUser> userMananger,
            ILogger<IdentityAuthService> logger, SignInManager<JwtUser> signInMananger, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _userManager = userMananger;
            _configuration = configuration;
            _signInManager = signInMananger;
        }

        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User Sign Out");
            return "Deconnected!";
        }

        public async Task<string> SignIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return "Tous les champs sont obligatoires, veuillez les remplire";

            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User sign In with password");

                //var issuer = _configuration.GetSection("jwt").GetSection("Issuer").Value;
                var tokehandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokeDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                //genrate toke
                var token = tokehandler.CreateToken(tokeDescriptor);

                //return token
                return tokehandler.WriteToken(token);
            }

            return "Enable to Connect , please retry again";
        }

        public async Task<string> SignUp(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("veuillez completer tout les champs , car ils sont tous obligatoire.");

            var newUser = new JwtUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = username,
                Email = email
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Account with password Created");

                return "Account Created";
            }

            return "Faild to Create Account with password";
        }
    }
}

using System;
using System.Linq;
using JWTSecure.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using JWTSecure.Services.interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;

namespace JWTSecure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //get Method
        public async Task<string> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
                return "Impossible de vous connecter car certains champs obligatoires ne sont pas remplis";

            var result = _context.TbUsers.Where(e => e.EmailAdress == email && e.Password == password).FirstOrDefault();

            if (result == null)
                return "Impossible To Connect";

            //token base config
            var issuer = _configuration.GetSection("jwt").GetSection("Issuer").Value;
            var tokehandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokeDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.Name,password)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
            };

            //genrate toke
            var token = tokehandler.CreateToken(tokeDescriptor);

            //return token
            return tokehandler.WriteToken(token);
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        //post Method
        public async Task<string> Register(string usernane, string email, string password)
        {
            if (String.IsNullOrWhiteSpace(usernane) && String.IsNullOrWhiteSpace(email) && String.IsNullOrWhiteSpace(password))
                return "Veuillez remplire ces champs svp";

            await _context.TbUsers.AddAsync(new Models.AppUser()
            {
                ID = Guid.NewGuid().ToString(),
                UserName = usernane,
                EmailAdress = email,
                Password = password
            });
            await _context.SaveChangesAsync();

            return "User Created Account with password";
        }
    }
}

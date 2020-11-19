using System;
using System.Linq;
using JWTSecure.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using JWTSecure.Services.interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace JWTSecure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(string usernane, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

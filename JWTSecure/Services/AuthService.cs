using JWTSecure.Context;
using JWTSecure.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

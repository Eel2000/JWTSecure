﻿using System.Threading.Tasks;

namespace JWTSecure.Services.interfaces
{
    public interface IAuthService
    {
        Task<bool> Logout();
        Task<string> Login(string email, string password);
        Task<string> Register(string usernane, string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTSecure.Services.interfaces
{
    public interface IIdentityAuthService
    {
        Task<string> Logout();
        Task<string> SignIn(string username, string password);
        Task<string> SignUp(string username, string email, string password);
    }
}

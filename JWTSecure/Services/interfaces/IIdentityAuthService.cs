using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTSecure.Services.interfaces
{
    public interface IIdentityAuthService
    {
        Task Logout();
        Task SignIn(string username, string password);
        Task SignUp(string username, string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTSecure.Models
{
    public class AppUser
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }
}

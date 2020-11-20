using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet("List")]
        public async Task<IActionResult> ListStudent()
        {
            var list = new List<string>() { "eliezer", "emma", "dan" };
            return Json(list);
        }
    }
}

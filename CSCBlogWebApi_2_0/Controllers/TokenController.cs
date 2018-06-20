using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [Route("/login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return BadRequest();
        }
    }
}
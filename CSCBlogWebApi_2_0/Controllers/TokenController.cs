using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Business.IService;
using CSCBlogWebApi_2_0.Business.Service;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using CSCBlogWebApi_2_0.Infrastructure.JWT;
using CSCBlogWebApi_2_0.Model.Authentication;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IUserInfoService busines = new UserInfoService();

        private readonly IConfiguration configuration;

        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var user = await busines.GetUser(model.Account, model.Password);
            var user = await busines.GetUser(model.Account);
            if (null != user)
            {
                if(model.Password!= Secret.GetMD5(user.Password))
                {
                    ModelState.AddModelError("Password", "密码错误");
                    return BadRequest(ModelState);
                }
                return new ObjectResult(JWTHelper.GenerateToken(user, configuration));
            }
            else
            {
                ModelState.AddModelError("Account", "用户名错误");
                return BadRequest(ModelState);
            }
        }
    }
}
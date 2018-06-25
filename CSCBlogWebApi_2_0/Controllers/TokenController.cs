using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Service.IService;
using CSCBlogWebApi_2_0.Service.Service;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using CSCBlogWebApi_2_0.Infrastructure.JWT;
using CSCBlogWebApi_2_0.Model.Authentication;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSCBlogWebApi_2_0.Business.Interface;
using CSCBlogWebApi_2_0.Business.Implements;
using CSCBlogWebApi_2_0.Extend;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IUserInfoBusiness busines;

        private readonly IConfiguration configuration;

        public TokenController(IConfiguration configuration, IUserInfoBusiness _business)
        {
            this.configuration = configuration;
            this.busines = _business;
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return ModelStateExtend.ToActionResultFirst(ModelState);
            }
            var jwtToken = new JwtTokenModel()
            {
                JwtKey= configuration.GetSection("Jwt")["JwtKey"],
                JwtIssuer = configuration.GetSection("Jwt")["JwtIssuer"],
                JwtAudience = configuration.GetSection("Jwt")["JwtAudience"],
                JwtExpireDays= double.Parse(configuration.GetSection("Jwt")["JwtExpireDays"])
            };
            var result=  await busines.Login(model, jwtToken);
            return ModelStateExtend.ToActionResult(result);
        }
    }
}
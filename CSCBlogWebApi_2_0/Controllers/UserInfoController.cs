using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Business.IService;
using CSCBlogWebApi_2_0.Business.Service;
using CSCBlogWebApi_2_0.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService busines = new UserInfoService();
        // GET: api/UserInfo
        [HttpGet]
        public IEnumerable<User_Info> Get()
        {
            return busines.GetList();
        }

        [HttpPost("getuser")]
        public async Task<User_Info> GetUserAsync([FromBody]User_Info userInfo)
        {
            return await busines.GetUser(userInfo.Name, userInfo.Password);
        }

        //[HttpPost("getuser")]
        //public IEnumerable<User_Info> GetUser([FromBody]User_Info userInfo)
        //{
        //    return _userinfo_service.User(userInfo.Name, userInfo.Password);
        //}
    }
}
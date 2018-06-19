using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.UserInfoService;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/UserInfo")]
    public class UserInfoController : Controller
    {
        private IUserInfo_Service _userinfo_service;
        public UserInfoController(IUserInfo_Service user_service)
        {
            _userinfo_service = user_service;
        }
        // GET: api/UserInfo
        [HttpGet]
        public IEnumerable<User_Info> Get()
        {
            return _userinfo_service.User();
        }

        [HttpPost("getuserasync")]
        public async Task<User_Info> GetUserAsync([FromBody]User_Info userInfo)
        {
            return await _userinfo_service.GetUserAsync(userInfo.Name, userInfo.Password);
        }

        [HttpPost("getuser")]
        public IEnumerable<User_Info> GetUser([FromBody]User_Info userInfo)
        {
            return _userinfo_service.User(userInfo.Name, userInfo.Password);
        }
    }
}
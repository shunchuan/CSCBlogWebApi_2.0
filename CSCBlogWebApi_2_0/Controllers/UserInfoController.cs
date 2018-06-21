using System.Collections.Generic;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Business.IService;
using CSCBlogWebApi_2_0.Business.Service;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using CSCBlogWebApi_2_0.Model.TableModel;
using Microsoft.AspNetCore.Mvc;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService business = new UserInfoService();
        // GET: api/UserInfo
        [HttpGet]
        public async Task<IEnumerable<User_Info>> Get()
        {
            return await business.GetList();
        }

        [HttpPost("getuser")]
        public async Task<User_Info> GetUserAsync([FromBody]User_Info userInfo)
        {
            return await business.GetUser(userInfo.Account, userInfo.Password);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody]User_Info userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var user = await busines.GetUser(model.Account, model.Password);
            var user = await business.GetUser(userInfo.Account);
            if (null != user)
            {
                ModelState.AddModelError("Account", "用户名已存在");
                return BadRequest(ModelState);
            }
            userInfo.Password = Secret.GetMD5(userInfo.Password);
            return new ObjectResult(business.AddAsync(userInfo));
        }
    }
}
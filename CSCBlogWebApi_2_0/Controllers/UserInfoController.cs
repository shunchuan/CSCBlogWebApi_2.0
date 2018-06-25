using System.Collections.Generic;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using CSCBlogWebApi_2_0.Model.TableModel;
using Microsoft.AspNetCore.Mvc;
using CSCBlogWebApi_2_0.Business.Interface;
using CSCBlogWebApi_2_0.Business.Implements;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using System.Linq;
using CSCBlogWebApi_2_0.Extend;
using System;

namespace CSCBlogWebApi_2_0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        private readonly IUserInfoBusiness business ;

        public UserInfoController(IUserInfoBusiness _business)
        {
            business = _business;
        }

        // GET: api/UserInfo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelStateExtend.ToActionResult(await business.GetList());
            }
            catch (Exception ex)
            {
                var result = new ResultMessage() { Status = "0", Message = ex.Message, Response = ex };
                return ModelStateExtend.ToActionResult(result);
            }
        }

        [HttpPost("getuser")]
        public async Task<User_Info> GetUserAsync([FromBody]User_Info userInfo)
        {
            return await business.GetUserAsync(userInfo);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody]User_Info userInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ModelStateExtend.ToActionResultFirst(ModelState);
                    //return BadRequest(ModelState);
                }

                return ModelStateExtend.ToActionResult(await business.AddAsync(userInfo as User_Info));
            }
            catch (Exception ex)
            {
                var result = new ResultMessage() { Status = "0", Message = ex.Message, Response = ex };
                return ModelStateExtend.ToActionResult(result);
            }
        }
    }
}
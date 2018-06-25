using CSCBlogWebApi_2_0.Business.Interface;
using CSCBlogWebApi_2_0.Domain;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using CSCBlogWebApi_2_0.Infrastructure.JWT;
using CSCBlogWebApi_2_0.Model.Authentication;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using CSCBlogWebApi_2_0.Model.TableModel;
using CSCBlogWebApi_2_0.Service.IService;
using CSCBlogWebApi_2_0.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace CSCBlogWebApi_2_0.Business.Implements
{
    public class UserInfoBusiness: IUserInfoBusiness
    {

        private readonly IUserInfoService business ;

        public UserInfoBusiness()
        {
            business = new UserInfoService(DbContextFactory.Create());
        }
        public async Task<ResultMessage> Login(LoginModel model,JwtTokenModel jwtToken)
        {
            var user = await business.GetUser(model.Account);
            if (null != user)
            {
                if (user.Password != SecretHelper.Md532(model.Password))
                {
                    return new ResultMessage() { Status="0",Message= "密码错误" };
                }
                return new ResultMessage() { Status = "1", Response = JWTHelper.GenerateToken(user, jwtToken) };
            }
            else
            {
                return new ResultMessage() { Status = "0", Message = "用户名错误" };
            }
        }

        public async Task<ResultMessage> GetList()
        {
            var result= (await Task.Run(() => business.GetList())).ToList();
            return new ResultMessage() { Status = "1", Response = result };
        }
        
        public async Task<User_Info> GetUserAsync(User_Info userInfo)
        {
            return await business.GetUser(userInfo.Account, userInfo.Password);
        }
        
        public async Task<ResultMessage> AddAsync(User_Info userInfo)
        {
            //var user = await busines.GetUser(model.Account, model.Password);
            var user = await business.GetUser(userInfo.Account);
            if (null != user)
            {
                return new ResultMessage() { Status="0",Message= "用户名已存在" };
            }
            userInfo.Password = SecretHelper.Md532(userInfo.Password);
            return new ResultMessage() { Status = await business.AddAsync(userInfo) ? "1" : "0" };
        }
    }
}

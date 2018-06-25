using CSCBlogWebApi_2_0.Model.Authentication;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using CSCBlogWebApi_2_0.Model.TableModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Business.Interface
{
    public interface IUserInfoBusiness
    {
        Task<ResultMessage> Login(LoginModel model, JwtTokenModel jwtToken);

        Task<ResultMessage> GetList();

        Task<User_Info> GetUserAsync(User_Info userInfo);

        Task<ResultMessage> AddAsync(User_Info userInfo);
    }
}

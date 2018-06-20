using CSCBlogWebApi_2_0.Domain.Entity;
using CSCBlogWebApi_2_0.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Business.IService
{
    public interface IUserInfoService:  IBaseRepository<User_Info>
    {
        Task<User_Info> GetUser(string username, string password);
    }
}

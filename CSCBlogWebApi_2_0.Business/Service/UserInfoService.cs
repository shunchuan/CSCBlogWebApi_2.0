using CSCBlogWebApi_2_0.Business.IService;
using CSCBlogWebApi_2_0.Domain;
using CSCBlogWebApi_2_0.Domain.Entity;
using CSCBlogWebApi_2_0.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Business.Service
{
    public class UserInfoService: BaseRepository<User_Info>, IUserInfoService
    {
        public UserInfoService() : base(DbContextFactory.Create())
        {

        }

        public async Task<User_Info> GetUser(string username, string password)
        {
            return await GetSingle(u => u.Name == username && u.Password == password);
        }
    }
}

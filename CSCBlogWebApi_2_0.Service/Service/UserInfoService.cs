using CSCBlogWebApi_2_0.Service.IService;
using CSCBlogWebApi_2_0.Domain;
using CSCBlogWebApi_2_0.Domain.IRepository;
using CSCBlogWebApi_2_0.Domain.Repository;
using CSCBlogWebApi_2_0.Model.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSCBlogWebApi_2_0.Service.Service
{
    public class UserInfoService : BaseRepository<User_Info>, IUserInfoService
    //public class UserInfoService:IUserInfoService
    {
        //private readonly IBaseRepository<User_Info> baseRepository;
        public UserInfoService(DbContext dBContext) :base(dBContext)
        {
            //baseRepository = new BaseRepository<User_Info>(DbContextFactory.Create());
        }

        //public async Task<IQueryable<User_Info>> GetList()
        //{
        //    return await Task.Run(()=> GetList());
        //}

        public async Task<User_Info> GetUser(string account, string password)
        {
            return await GetSingle(u => u.Account == account && u.Password == password);
        }

        public async Task<User_Info> GetUser(string account)
        {
            return await GetSingle(u => u.Account == account);
        }

        public async Task<bool> AddAsync(User_Info user_Info)
        {
            return await Task.Run(() => Add(user_Info) > 0);
        }
    }
}

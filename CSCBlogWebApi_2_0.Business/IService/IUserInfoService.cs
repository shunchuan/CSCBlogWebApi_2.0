using CSCBlogWebApi_2_0.Domain.IRepository;
using CSCBlogWebApi_2_0.Model.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Business.IService
{
    public interface IUserInfoService
    {
        Task<IQueryable<User_Info>> GetList();

        Task<User_Info> GetUser(string account, string password);

        Task<User_Info> GetUser(string account);

        Task<bool> AddAsync(User_Info user_Info);
    }
}

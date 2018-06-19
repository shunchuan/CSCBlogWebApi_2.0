using DAL;
using Entity.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Service.UserInfoService
{
    public class UserInfo_Service: IUserInfo_Service
    {
        private MySqlDbContext _dbContext;
        public UserInfo_Service(MySqlDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public List<User_Info> User()
        {
            var result = _dbContext.UserInfo;
            var icoll = from User_Info in result
                        where User_Info.Name!= null
                        select User_Info;
            icoll.ToList();
            
            return _dbContext.UserInfo.ToList<User_Info>();
        }

        public IQueryable<User_Info> User(string username,string password)
        {
            using (var dbcontext = new DBContext())
            {
                var result = from user in _dbContext.UserInfo
                             where user.Name == username && user.Password == password
                             select user;
                return result;
            }
        }

        public Task<User_Info> GetUserAsync(string username, string password)
        {
            using (var dbcontext = new DBContext())
            {
                return _dbContext.UserInfo.Where(u => u.Name == username && u.Password == password)
                    .FirstOrDefaultAsync();
            }
        }
    }
}

using ET = Entity.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Service.UserInfoService
{
    public interface IUserInfo_Service
    {
        List<ET.User_Info> User();
        IQueryable<ET.User_Info> User(string username, string password);


        Task<ET.User_Info> GetUserAsync(string username, string password);
    }
}

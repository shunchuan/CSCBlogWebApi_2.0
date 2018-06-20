using CSCBlogWebApi_2_0.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Repository.DALMySql
{
    public class UserInfo : BaseDAL<Domain.Entity.User_Info>, IDAL.IUserInfo
    {
        public UserInfo():base(DbContextFactory.Create())
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CSCBlogWebApi_2_0.Infrastructure.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CSCBlogWebApi_2_0.Domain
{
    public partial class DbContextFactory
    {
        /// <summary>
        /// 创建EF上下文对象,已存在就直接取,不存在就创建,保证线程内是唯一。
        /// </summary>
        public static DbContext Create()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)
            {
                var dbType = ReadDatabase.CreateInstance().ReadTypeOfDataBase();
                switch (dbType)
                {
                    case Enum.DBTYPE.MySql:
                        dbContext = new DBContext(ReadDatabase.CreateInstance().ReadConnectionStrOfDataBase());
                        break;
                    default:
                        break;
                }
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}

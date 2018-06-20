using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Repository
{
    /// <summary>
    /// EF 上下文 工厂
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// 获取 EF 上下文对象
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}

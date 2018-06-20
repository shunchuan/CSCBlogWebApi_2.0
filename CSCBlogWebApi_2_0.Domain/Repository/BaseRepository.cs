using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSCBlogWebApi_2_0.Domain.Repository
{
    public class BaseRepository<T> : IRepository.IBaseRepository<T> where T : class, new()
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _set;

        public BaseRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            _set = _dbContext.Set<T>();
        }

        /// <summary>
        /// 添加数据实体
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns>数据库更新受影响的行数</returns>
        public virtual int Add(T model)
        {
            _set.Add(model);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除数据实体
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public virtual int Del(T model)
        {
            RemoveHoldingEntityInContext(model);
            ////将 对象 添加到 EF中
            //DbEntityEntry entry = _dbContext.Entry<T>(model);
            ////设置 对象的包装 状态为 Unchanged
            //entry.State = EntityState.Deleted;
            //
            _set.Attach(model);
            _set.Remove(model);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 根据指定条件批量删除
        /// </summary>
        /// <param name="delWhere">删除条件 Linq表达式</param>
        /// <returns>数据库更新受影响行数</returns>
        public virtual int DelBy(Expression<Func<T, bool>> delWhere)
        {

            //查询要删除的数据
            List<T> listDeleting = _set.Where(delWhere).ToList();
            //将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                RemoveHoldingEntityInContext(u);
                _set.Attach(u);//先附加到 EF容器
                _set.Remove(u);//标识为 删除 状态
            });
            //一次性 生成sql语句到数据库执行删除
            return _dbContext.SaveChanges();
        }

        public virtual bool Exist(Expression<Func<T, bool>> whereLambda)
        {
            int count = _set.AsNoTracking().Where(whereLambda).Count();
            if (count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取所有数据列表
        /// </summary>
        /// <returns>数据列表</returns>
        public virtual IQueryable<T> GetList()
        {
            return _set.AsNoTracking();
        }

        public virtual Task<T> GetSingle(Expression<Func<T, bool>> whereLambda)
        {
            return _set.FirstOrDefaultAsync(whereLambda);
        }

        /// <summary>
        /// 根据指定条件查询数据
        /// </summary>
        /// <param name="whereLambda">查询条件 Linq表达式</param>
        /// <returns>符合条件的数据列表</returns>
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> whereLambda)
        {
            return _set.Where(whereLambda).AsNoTracking();
        }

        #region 获取所有符合要求的列表   条件 + 排序
        /// <summary>
        /// 获取所有符合要求的列表   条件 + 排序
        /// </summary>
        /// <typeparam name="TKey">要用作排序 字段</typeparam>
        /// <param name="whereLambda">查询条件Linq表达式</param>
        /// <param name="orderLambda">排序条件Linq表达式</param>
        /// <returns>符合要求的数据列表</returns>
        public virtual IQueryable<T> Get<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return _set.Where(whereLambda).AsNoTracking().OrderBy(orderLambda);
        }
        #endregion

        #region 根据条件和排序条件 查询分页数据 + IQueryable<T> GetPagedList
        /// <summary>
        /// 查询分页数据 + IQueryable<T> GetPagedList
        /// </summary>
        /// <typeparam name="TKey">排序用到的键值</typeparam>
        /// <param name="pageIndex">页码索引，第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">查询条件Linq表达式</param>
        /// <param name="orderBy">排序条件Linq表达式</param>
        /// <param name="isAsc">是否是正向排序</param>
        /// <returns>符合要求的数据列表</returns>
        public virtual IQueryable<T> GetPage<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            // 分页 一定注意： Skip 之前一定要 OrderBy
            if (isAsc)
            {
                return _set.Where(whereLambda).AsNoTracking().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _set.Where(whereLambda).AsNoTracking().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        #endregion

        #region 查询分页数据（返回符合要求的记录总数）+ GetPagedList
        /// <summary>
        /// 查询分页数据（返回符合要求的记录总数）+ GetPagedList
        /// </summary>
        /// <typeparam name="TKey">排序用到的键值</typeparam>
        /// <param name="pageIndex">页码索引，第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowsCount">总记录数</param>
        /// <param name="whereLambda">查询条件Linq表达式</param>
        /// <param name="orderBy">排序条件Linq表达式</param>
        /// <param name="isAsc">是否正序排列</param>
        /// <returns>符合要求的列表</returns>
        public virtual IQueryable<T> GetPage<TKey>(int pageIndex, int pageSize, ref int rowsCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            //查询总的记录数
            rowsCount = _set.Where(whereLambda).Count();
            // 分页 一定注意： Skip 之前一定要 OrderBy
            if (isAsc)
            {
                return _set.Where(whereLambda).AsNoTracking().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _set.Where(whereLambda).AsNoTracking().OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        #endregion

        public virtual int Modify(T model, params string[] proNames)
        {
            RemoveHoldingEntityInContext(model);
            //4.1将 对象 添加到 EF中
            var entry = _dbContext.Entry(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            foreach (string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            //4.4一次性 生成sql语句到数据库执行
            return _dbContext.SaveChanges();
        }

        public virtual int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] PropertyNames)
        {
            RemoveHoldingEntityInContext(model);
            List<T> list = _set.Where(whereLambda).AsNoTracking().ToList();
            foreach (T item in list)
            {
                //将对象添加到EF对象
                var entry = _dbContext.Entry<T>(item);
                //设置状态为 Unchanged
                entry.State = EntityState.Unchanged;

                foreach (string property in PropertyNames)
                {
                    entry.Property(property).IsModified = true;
                }
            }
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 执行SQL 语句
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="paras">参数</param>
        /// <returns>执行sql语句后受影响的行数</returns>
        public virtual int ExcuteSql(string strSql, params object[] paras)
        {
            return _dbContext.Database.ExecuteSqlCommand(strSql, paras);
        }

        /// <summary>
        /// 监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool RemoveHoldingEntityInContext(T entity)
        {
            //ObjectContext objContext = ((IObjectContextAdapter)_dbContext).ObjectContext;
            //var objSet = objContext.CreateObjectSet<T>();
            //var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
            //object foundEntity;
            //var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            //if (exists)
            //{
            //    objContext.Detach(foundEntity);
            //}
            //return (exists);
            return true;
        }

    }
}

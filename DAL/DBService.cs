using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class DBService<T>
    {
        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            using (var dbcontext=new DBContext())
            {
                var dbprop = dbcontext.GetType().GetProperties();
            }

            return null;
        }
    }
}

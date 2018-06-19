using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entity.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DAL
{
    [TestClass]
    public class DBServiceTest
    {
        [TestMethod]
        public void GetListBy()
        {
            DBService<User_Info> dbService=new DBService<User_Info>();
            Assert.IsNull(dbService.GetListBy(c => c.Name == "Admin", o => o.Name));
        }
    }
}

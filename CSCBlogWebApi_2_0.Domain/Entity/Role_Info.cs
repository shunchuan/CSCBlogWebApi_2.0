using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Domain.Entity
{
    public class Role_Info
    {
        public int? Id { set; get; }
        public string Role_Name { set; get; }

        public int? Role_Level { set; get; }

        public string Creator { set; get; }
        public DateTime? Created_Date { set; get; }
        public string Updator { set; get; }
        public DateTime? Updated_Date { set; get; }
    }
}

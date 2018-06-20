using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Domain.Entity
{
    public class User_Info
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public string Password { set; get; }
        public string Sex { set; get; }
        public int Age { set; get; }
    }
}

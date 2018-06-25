using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.TableModel
{
    public class User_Info
    {
        public int Id { set; get; }

        [Required]
        public virtual string Account { set; get; }


        [Required]
        public virtual string Name { set; get; }


        [Required]
        public virtual string Password { set; get; }
        public string Sex { set; get; }
        public int Age { set; get; }
    }
}

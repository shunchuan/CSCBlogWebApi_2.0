using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Account { set; get; }

        [Required]
        public string Password { set; get; }
    }
}

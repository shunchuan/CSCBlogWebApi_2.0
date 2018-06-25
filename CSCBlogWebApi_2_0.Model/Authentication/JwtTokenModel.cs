using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.Authentication
{
    public class JwtTokenModel
    {
        public string JwtKey { set; get; }

        public string JwtIssuer { set; get; }

        public string JwtAudience { set; get; }

        public double JwtExpireDays { set; get; }
    }
}

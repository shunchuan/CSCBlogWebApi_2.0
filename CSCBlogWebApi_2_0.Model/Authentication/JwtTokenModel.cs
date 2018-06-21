using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.Authentication
{
    public class JwtTokenModel
    {
        public string issuer { set; get; }

        public string audience { set; get; }

        public string key { set; get; }

        public double expiresday { set; get; }
    }
}

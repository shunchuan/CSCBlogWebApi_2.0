using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.ResponseModel
{
    public class TokenResponseModel
    {
        public string type { get; set; }

        public string access_token { get; set; }

        public DateTime expires { get; set; }
    }
}

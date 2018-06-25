using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.ResponseModel
{
    public class ResultMessage
    {
        /// <summary>
        /// 状态 （0失败 1 成功）
        /// </summary>
        public string Status { set; get; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public Object Response { set; get; }
    }
}

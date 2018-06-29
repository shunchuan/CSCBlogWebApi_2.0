using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.TableModel
{
    /// <summary>
    /// DB_ArticleTag:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DB_ArticleTag
    {
        public DB_ArticleTag()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int ArticleTag_ID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ArticleTag_ArticleID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ArticleTag_TagID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int Delete_Status { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Creator { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Created_Date { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Updator { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Updated_Date { set; get; }
        #endregion Model

    }
}

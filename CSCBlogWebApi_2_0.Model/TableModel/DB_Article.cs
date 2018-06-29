using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.TableModel
{
    /// <summary>
	/// DB_Article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class DB_Article
    {
        public DB_Article()
        { }
        #region Model
        /// <summary>
        /// auto_increment
        /// </summary>
        public int Article_ID { set; get; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Article_Title { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Article_Content { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public long Article_IssuingDate { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int Article_MasterID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? Article_Count { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? Article_From { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Article_Reproduced { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int Delete_Status { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Created_Date { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Creator { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Updated_Date { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Updater { set; get; }
        #endregion Model

    }
}

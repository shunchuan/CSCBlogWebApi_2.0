using System;
using System.Collections.Generic;
using System.Text;

namespace CSCBlogWebApi_2_0.Model.TableModel
{
    /// <summary>
	/// DB_Tag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class DB_Tag
    {
        public DB_Tag()
        { }
        #region Model

        public int Tag_ID { get; set; }

        public string Tag_Name { get; set; }

        public int Delete_Status { get; set; } = 0;

        public DateTime? Created_Date { get; set; }

        public string Creator { get; set; }

        public DateTime? Updated_Date { get; set; }

        public string Updater { get; set; }

        #endregion Model

    }
}

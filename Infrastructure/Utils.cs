using Enum;
using System.IO;
using System.Xml;

namespace Infrastructure
{
    /// <summary>
    /// 公共类库
    /// </summary>
    public class Utils : UtilityBase
    {
        /// <summary>
        /// 声明一个已经是否声明自身类的对象
        /// </summary>
        private volatile static Utils _instance = null;

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object lockHelper = new object();

        /// <summary>
        /// 
        /// </summary>
        private Utils() { }

        /// <summary>
        /// 创建单实例（函数方式）
        /// </summary>
        /// <returns></returns>
        public static Utils CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new Utils();
                }
            }
            return _instance;
        }

        /// <summary>
        /// 读取数据库类型 mysql, oracle, sqlserver, access
        /// </summary>
        /// <returns></returns>
        public DBTYPE ReadTypeOfDataBase()
        {
            DBTYPE dbType = DBTYPE.None;
            string s = Directory.GetCurrentDirectory() + @"\Config\System\";

            XmlDocument doc = new XmlDocument();

            string type = "";

            doc.Load(s + "DataBase.xml");

            var nodes = doc.SelectSingleNode("database").ChildNodes;

            foreach (XmlNode item in nodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.Name == "type")
                {
                    type = xe.InnerText;
                    break;
                }
            }

            switch (type.ToLower())
            {
                case "mysql":
                    dbType = DBTYPE.MySql;
                    break;
                case "oracle":
                    dbType = DBTYPE.Oracle;
                    break;
                case "sqlserver":
                    dbType = DBTYPE.SqlServer;
                    break;
                case "access":
                    dbType = DBTYPE.Access;
                    break;
            }
            return dbType;
        }

        /// <summary>
        /// 读取数据库链接字符串
        /// </summary>
        /// <returns></returns>
        public string ReadConnectionStrOfDataBase()
        {
            string s = Directory.GetCurrentDirectory() + @"\Config\System\";

            XmlDocument doc = new XmlDocument();

            string connectionStr = "";

            doc.Load(s + "DataBase.xml");

            var nodes = doc.SelectSingleNode("database").ChildNodes;

            foreach (XmlNode item in nodes)
            {
                XmlElement xe = (XmlElement)item;
                if (xe.Name == "connectionStr")
                {
                    connectionStr = xe.InnerText;
                    break;
                }
            }
            return connectionStr;
        }



    }
}

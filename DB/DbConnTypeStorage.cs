using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.DB
{
    public class DbConnTypeStorage
    {
        public static string defaultDbConnString;
        private static Dictionary<string, string> dbConnType;

        /// <summary>
        /// 保存数据库链接配置
        /// </summary>
        /// <param name="_dbConnType">数据库连接配置</param>
        /// <param name="setDefaultDbConntStr_key">默认数据库连接</param>
        public static void setDbConnType(Dictionary<string,string> _dbConnType, string setDefaultDbConntStr_key)
        {
            if (dbConnType == null)
            {
                dbConnType = _dbConnType;
                defaultDbConnString = dbConnType[setDefaultDbConntStr_key];
            }
        }

        public static string getDbConnString(string dbconn_key)
        {
            if (dbconn_key == null)
            {
                throw new ArgumentNullException(nameof(dbconn_key));
            }

            return dbConnType[dbconn_key];
        }
    }
}

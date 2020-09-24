using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.DB
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DbTypeEnum
    {
        [Description("SqlServerConnection")]
        SqlServer=1,

        [Description("OracleConnection")]
        Oracle=2,

        [Description("MySqlConnection")]
        MySql = 3,

        [Description("SqlLiteConnection")]
        SqlLite = 4
    }
}

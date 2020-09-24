using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Beans
{
    public class DbConnType
    {
        public string SqlServerConnection { get; set; }
        public string OracleConnection { get; set; }
        public string MySqlConnection { get; set; }
        public string SqlLiteConnection { get; set; }
    }
}

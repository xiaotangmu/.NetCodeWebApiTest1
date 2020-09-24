using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApi1.Beans;
using WebApi1.DB;

namespace WebApi1.Dao
{
    public class UserDao
    {
        public async List<User> selectAll()
        {
            string connstr = DbConnTypeStorage.defaultDbConnString;
            SqlConnection connection = new SqlConnection(connstr);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from t_user";
            await connection.OpenAsync();
            var object = await command.ExecuteReader();

    }
}

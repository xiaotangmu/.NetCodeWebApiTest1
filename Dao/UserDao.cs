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
        public List<User> selectAll()
        {
            List<User> list = new List<User>();
            string connstr = DbConnTypeStorage.defaultDbConnString;
            SqlConnection connection = new SqlConnection(connstr);
            SqlCommand command = connection.CreateCommand();
            SqlDataReader reader = null;
            command.CommandText = "select * from t_user";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetInt32(2) + ":" + reader.GetString(0) + ":" + reader.GetString(1));
                    User user = new User(reader.GetInt32(2), reader.GetString(0), reader.GetString(1));
                    list.Add(user);
                }
            }
            return list;
        }
    }
}

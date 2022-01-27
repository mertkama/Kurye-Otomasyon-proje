using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class BaseDal
    {
        public string connectionString="";

        public BaseDal()
        {
            connectionString = @"Server= .; Database= KuryeOtomasyon; Integrated Security=True;";
        }

        public SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = connectionString;


            return connection;
        }
    }
}

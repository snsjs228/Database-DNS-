using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //используем бд


namespace DNS
{
    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=PC-7; Initial Catalog = DNS; Integrated Security=True"); //строка подключения
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if(sqlConnection.State== System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}

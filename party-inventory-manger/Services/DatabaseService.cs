using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PartyInventoryManger.Services
{
    //this is were we log onto the database and such
    public class DatabaseService
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = null;
            SqlConnection sqlConnection;
            connectionString = "Database = storeDB;Server=localhost;Integrated Security = SSPI;";

            sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public static void CloseSqlConnection(SqlConnection sqlConnection)
        //{
        //    sqlConnection.Close();

        //    if (sqlConnection != null)
        //    {
        //        sqlConnection.Dispose();
        //    }
        //}

        public static bool TableExists(string tableName)
        {
            return false;
        }





    }
}

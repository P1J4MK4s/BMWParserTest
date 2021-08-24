using System;
using System.Data;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class ConnectionToDB
    {
        //private readonly string sqlParams = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Study\Parser for AutoAll\AutoPatrs.mdf';User ID=AdminUser;Password=Lorgar17";
        private readonly string sqlParams = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoPatrs;Integrated Security=True";

        public SqlConnection sqlConnection;
        public ConnectionToDB()
        {
            sqlConnection = new SqlConnection(sqlParams);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
                Console.WriteLine("Connection Open.");
        }
        ~ConnectionToDB() 
        {
            sqlConnection.Close();
            if (sqlConnection.State == ConnectionState.Closed)
                Console.WriteLine("Connection Closed.");
        }
    }
}

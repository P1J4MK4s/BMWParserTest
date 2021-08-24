using Parser_for_AutoAll.Core.Parser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parser_for_AutoAll.Core.SQL
{
    class SqlService
    {
        public static void Insert(List<Model> models)
        {
            ConnectionToDB connection = new();
            string query;

            foreach (Model model in models)
            {
                query = $"INSERT INTO [Parts] (Name, Article, OrderCode, Vendor, Price, PathToPicture) VALUES ('{model.Name}','{model.Article}','{model.OrderCode}','{model.Vendor}','{model.Price}','{model.PictureFolder}')";
                SqlCommand command = new(query, connection.sqlConnection);
                command.ExecuteNonQuery();
            }
        }
        public static List<Model> GetAll()
        {
            ConnectionToDB connection = new();
            List<Model> models = new();
            string query = "SELECT * FROM Parts";
            SqlCommand commandOutput = new(query, connection.sqlConnection);
            SqlDataReader reader = commandOutput.ExecuteReader();
            while (reader.Read())
            {
                Model model = new();
                model.Name = reader[1].ToString();
                model.Article = reader[2].ToString();
                model.OrderCode = reader[3].ToString();
                model.Vendor = reader[4].ToString();
                model.Price = reader[5].ToString();
                model.PictureFolder = reader[6].ToString();
                models.Add(model);
            }
            return models;
        }
    }
}

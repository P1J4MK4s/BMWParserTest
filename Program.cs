using Parser_for_AutoAll.Core.Parser;
using Parser_for_AutoAll.Core.SQL;
using System;
using System.Collections.Generic;

namespace Parser_for_AutoAll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Model> models = Parser.ParseHtml();
            Requester.DownloadPictures(models);
            //SqlService.Insert(models);
            List<Model> modelsFromDb = SqlService.GetAll();
            foreach (Model model in modelsFromDb)
            {
                Console.WriteLine($"Name :{model.Name}\n" +
                    $"Article :{model.Article}\n" +
                    $"Order code :{model.OrderCode}\n" +
                    $"Price :{model.Price}\n" +
                    $"Vendor :{model.Vendor}\n" +
                    $"Picture folder :{model.PictureFolder}"); 
            }
        }
    }
}

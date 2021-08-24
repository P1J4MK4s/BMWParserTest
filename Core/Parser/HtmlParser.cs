using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Parser_for_AutoAll.Core.Parser
{
    class Parser
    {
        public static List<Model> ParseHtml()
        {
            List<Model> models = new();

            string html = Requester.DownloadPage("https://www.avtoall.ru/bmw/");

            HtmlDocument document = new();

            if (string.IsNullOrEmpty(html))
                throw new Exception("DOM is null");

            document.LoadHtml(html);
            var tables = document.DocumentNode.SelectNodes(".//div[@class='list-compact']//div[@class='item item-elem']");

            if (tables == null)
                throw new Exception("Table is null");

            foreach (var table in tables)
            {
                Model model = new();

                model.Name = table.SelectSingleNode(".//div[@class='decr']//strong[@class='item-name']")?.InnerText;

                var articleNod = table.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//b");
                model.Article = articleNod?.InnerText.Replace("Артикул: ", "").Replace("все", "");

                var orderCodeNod = table.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//small");
                model.OrderCode = orderCodeNod?.InnerText.Replace("Код для заказа: ", "");

                var vendorNod = table.SelectSingleNode(".//div[@class='decr']//div//div[@class='info']//span[@class='text']");
                model.Vendor = vendorNod?.InnerText.Replace("                    Производитель: ", "");

                model.Price = table.SelectSingleNode(".//div[@class='right-block']//div[@class='price']//b[@class='price-internet']")?.InnerText;

                model.PictureLink = table.SelectSingleNode(".//div[@class='image']//a//img")?.Attributes["data-src"].Value;
                //string path = @"c:\picture";
                //Directory.CreateDirectory(path);
                //Requester.DownloadPicture(model.OrderCode, model.PictureLink, path);
                models.Add(model);
            }
            return models;
        }
    }
}

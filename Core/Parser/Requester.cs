using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Parser_for_AutoAll.Core.Parser
{
    class Requester
    {
        public static string DownloadPage(string link)
        {
            using WebClient webClient = new();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.131 Safari/537.36 Edg/92.0.902.73");
            return webClient.DownloadString(link);
        }
        public static string DownloadPicture(string unickName, string link, string path)
        {
            string fileName;
            using WebClient client = new();
            try
            {
                fileName = path + $"\\{unickName}.jpg";
                client.DownloadFile(link, fileName);
                return fileName;
            }
            catch (Exception)
            {
                return "no photo";
            }
        }
        public static void DownloadPictures(List<Model> models)
        {
            string fileName;
            string path = @"c:\picture";
            Directory.CreateDirectory(path);
            foreach (Model model in models)
            {
                try
                {
                    using WebClient webClient = new();
                    webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.131 Safari/537.36 Edg/92.0.902.73");
                    fileName = path + $"\\{model.OrderCode}.jpg";
                    webClient.DownloadFile(model.PictureLink, fileName);
                    model.PictureFolder = fileName;
                }
                catch (Exception)
                {
                    model.PictureFolder = "no photo";
                }
            }
        }
    }
}

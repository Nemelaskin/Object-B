using Object_B.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Object_B.Models.Context;
using Microsoft.AspNetCore.Hosting;

namespace Object_B.Services
{
    public class MapSaveService : IMapSaveService
    {
        AllDataContext context;
        IWebHostEnvironment webEnv;
        public MapSaveService(AllDataContext context, IWebHostEnvironment webEnv)
        {
            this.context = context;
            this.webEnv = webEnv;
        }
        public string SaveMapToRelativePath(MapModel uploadedFile, string path)
        {
            string test = uploadedFile.Map;
            string[] map = test.Split(',');
            try
            {
                //string directory = Directory.GetCurrentDirectory();
                string directory = webEnv.ContentRootPath + @"\wwwroot";
                string[] tempFormat = map[0].Split('/');
                tempFormat = tempFormat[1].Split(';');
                string format = tempFormat[0];
                string nameCompany = "";
                byte[] bytes = Convert.FromBase64String(map[1]);
                using (Image image = Image.FromStream(new MemoryStream(bytes)))
                {
                    directory = directory + path;
                    switch (format)
                    {
                        case "png":
                            image.Save(directory + @"\MainCompanyMap.png", ImageFormat.Png);
                            nameCompany = @"\MainCompanyMap.png";
                            directory += @"\MainCompanyMap.png";
                            break;
                        case "jpeg":
                            image.Save(directory + @"\MainCompanyMap.jpeg", ImageFormat.Jpeg);
                            nameCompany = @"\MainCompanyMap.jpeg";
                            directory += @"\MainCompanyMap.jpeg";
                            break;
                        default:
                            return "";
                    }
                }
                return path + nameCompany;
            }
            catch
            {
                return "";
            }
        }
        public void SaveMapToDataBase(string path, string nameCompany)
        {
            var company = context.Companies.SingleOrDefault(u => u.NameCompany == nameCompany);
            if (company != null)
            {
                company.MapLink = path;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Not find current company!");
            }
        }
    }
}

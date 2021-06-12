using Microsoft.AspNetCore.Mvc;
using Object_B.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Object_B.Models.Context;

namespace Object_B.Services.MapServices
{
    public class MapSave
    {
        AllDataContext context;
        public MapSave(AllDataContext context)
        {
            this.context = context;
        }
        public string SaveMapToRelativePath(MapModel uploadedFile, string path)
        {
            string test = uploadedFile.Map;
            string[] map = test.Split(',');
            try
            {
                string directory = Directory.GetCurrentDirectory();
                string[] tempFormat = map[0].Split('/');
                tempFormat = tempFormat[1].Split(';');
                string format = tempFormat[0];
                byte[] bytes = Convert.FromBase64String(map[1]);
                using (Image image = Image.FromStream(new MemoryStream(bytes)))
                {
                    
                    directory = directory + path;
                    Environment.CurrentDirectory = directory;
                    switch (format)
                    {
                        case "png":
                            image.Save("MainCompanyMap.png", ImageFormat.Png);
                            break;
                        case "jpeg":
                            image.Save("MainCompanyMap.jpeg", ImageFormat.Jpeg);
                            break;
                        case "jpg":
                            image.Save("MainCompanyMap.jpeg", ImageFormat.Jpeg);
                            break;
                        default:
                            return "";
                    }
                }
                return directory;
            }
            catch
            {
                return "";
            }
        }
        public void SaveMapToDataBase(string path, string nameCompany)
        {
            var company = context.Companies.SingleOrDefault(u => u.NameCompany == nameCompany);
            if(company != null)
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

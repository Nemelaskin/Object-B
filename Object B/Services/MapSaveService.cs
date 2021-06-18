using Object_B.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Object_B.Models.Context;

namespace Object_B.Services
{
    public class MapSaveService
    {
        AllDataContext context;
        public MapSaveService(AllDataContext context)
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
                    switch (format)
                    {
                        case "png":
                            image.Save(directory + @"\MainCompanyMap.png", ImageFormat.Png);
                            directory += @"\MainCompanyMap.png";
                            break;
                        case "jpeg":
                            image.Save(directory + @"\MainCompanyMap.jpeg", ImageFormat.Jpeg);
                            directory += @"\MainCompanyMap.jpeg";
                            break;
                        case "jpg":
                            image.Save(directory + @"\MainCompanyMap.jpeg", ImageFormat.Jpeg);
                            directory += @"\MainCompanyMap.jpeg";
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

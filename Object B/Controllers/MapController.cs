using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Object_B.Models.Context;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;
using Object_B.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        AllDataContext _context;
        IWebHostEnvironment _appEnvironment;
        public MapController(AllDataContext context, IWebHostEnvironment appEnviroment)
        {
            _context = context;
            _appEnvironment = appEnviroment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var image = System.IO.File.OpenRead("res/maket1.jpg");
            return File(image, "image/jpg");
        }

        [HttpPost("Download")]
        public ActionResult DownloadImages([FromBody] MapModel uploadedFile)
        {
            if (uploadedFile != null)
            {
                string test = uploadedFile.Map;
                string[] map = test.Split(',');
                try
                {
                    string[] tempFormat = map[0].Split('/');
                    tempFormat = tempFormat[1].Split(';');
                    string format = tempFormat[0];
                    byte[] bytes = Convert.FromBase64String(map[1]);
                    using (Image image = Image.FromStream(new MemoryStream(bytes)))
                    {
                        Directory.SetCurrentDirectory(@"D:\Users\cfcrt\source\repos\Object B\Object B\res\");
                        switch (format)
                        {
                            case "png":
                                image.Save("CompanyName.png", ImageFormat.Png);  // Or Png
                                break;
                            case "jpeg":
                                image.Save("CompanyName.jpeg", ImageFormat.Jpeg);  // Or Png
                                break;
                            case "jpg":
                                image.Save("CompanyName.jpeg", ImageFormat.Jpeg);  // Or Png
                                break;
                            default:
                                return BadRequest();
                        }
                    }
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}

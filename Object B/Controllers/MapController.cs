using Microsoft.AspNetCore.Mvc;
using System;
using Object_B.Models.Context;
using Microsoft.AspNetCore.Hosting;
using Object_B.Models;
using Object_B.Services.MapServices;

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
                MapSave mapSave = new MapSave(_context);
                string path = mapSave.SaveMapToRelativePath(uploadedFile, @"\res\Maps");
                if (path != "")
                {
                    try
                    {
                        mapSave.SaveMapToDataBase(path, uploadedFile.nameCompany);
                        return Ok();
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }
            }
            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using Object_B.Models.Context;
using Microsoft.AspNetCore.Hosting;
using Object_B.Models;
using Object_B.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;

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

        [HttpGet("ViewMap")]
        public ActionResult View(string nameCompany)
        {
            try
            {
                var company = _context.Companies.FirstOrDefault(u => u.NameCompany == nameCompany);
                Byte[] b = System.IO.File.ReadAllBytes(company.MapLink);
                return File(b, "image/png", "testingSendImage");
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost("Download")]
        public ActionResult DownloadImages([FromBody] MapModel uploadedFile)
        {
            if (uploadedFile != null)
            {
                MapSaveService mapSave = new MapSaveService(_context);
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

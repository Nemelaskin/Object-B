using Microsoft.AspNetCore.Mvc;
using System;
using Object_B.Models.Context;
using Object_B.Models;
using Object_B.Services;
using System.Linq;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        AllDataContext _context;
        IMapSaveService mapSave;
        public MapController(AllDataContext context, IMapSaveService mapSave)
        {
            _context = context;
            this.mapSave = mapSave;
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
                string path = mapSave.SaveMapToRelativePath(uploadedFile, @"\Maps");
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

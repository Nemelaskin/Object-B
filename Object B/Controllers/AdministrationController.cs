using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Object_B.Services;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        IConfiguration configuration;

        public AdministrationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("ViewBackup")]
        public IActionResult ViewBackup()
        {
            var list = BackupDBService.ReadBackup();
            return Ok(list);

        }
        [HttpGet("SetBackup")]
        public IActionResult SetBackup(string name)
        {

            BackupDBService.SetBackup(name, configuration);
            return Ok();

        }

        [HttpGet("ExecuteBackup")]
        public IActionResult ExecuteBackup()
        {
            try
            {
                BackupDBService.Backup(configuration);
                return Ok("HI coffe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }

        }
        [HttpGet("MakeReport")]
        public IActionResult MakeReport()
        {
            return Ok();
        }
    }
}

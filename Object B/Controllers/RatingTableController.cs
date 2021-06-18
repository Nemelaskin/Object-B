using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Object_B.Models;
using Object_B.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Object_B.Services;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RatingTableController : ControllerBase
    {
        AllDataContext context;
        public RatingTableController( AllDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("index")]
        public List<RatingTable> Rating()
        {
            List<RatingTable> ratTable = new List<RatingTable>();
            RatingTableService.TakeRatingTableForDB(context, ratTable);
            return ratTable;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Object_B.Models;
using Object_B.Models.Context;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class VisitsController : ControllerBase
    {
        private readonly AllDataContext _context;

        public VisitsController(AllDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            return await _context.Visits.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);

            if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        [HttpPut]
        public async Task<IActionResult> PutVisit(Visit visit)
        {
            _context.Entry(visit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisit", new { id = visit.VisitId }, visit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

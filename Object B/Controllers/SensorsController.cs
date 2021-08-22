using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Object_B.Models;
using Object_B.Models.Context;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly AllDataContext _context;

        public SensorsController(AllDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensors()
        {
            return await _context.Sensors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor sensor)
        {
            if (id != sensor.SensorId)
            {
                return BadRequest();
            }

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensor", new { id = sensor.SensorId }, sensor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorExists(int id)
        {
            return _context.Sensors.Any(e => e.SensorId == id);
        }
    }
}

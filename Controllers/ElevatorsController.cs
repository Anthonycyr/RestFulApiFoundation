using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
// using System.Data.Entity;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly ElevatorContext _context;

        public ElevatorsController(ElevatorContext context)
        {
            _context = context;
        }

        // GET: api/Elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> GetElevators()
        {
            return await _context.elevators.ToListAsync();
        }


        // GET: api/Elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }
        // GET: api/Elevators/status
        [HttpGet("status")]
        public async Task<List<Elevator>> GetListElevator(string Status)
        {
            // var offlineStatus= new[] {"Offline", "Intervention"};
            var elevator = await _context.elevators.Where(x => x.status == "Offline" || x.status == "Intervention").ToListAsync();
            return elevator;
        }
        [HttpGet("/getCustomerElevator/{column_id}")]
        public async Task<List<Elevator>> customerElevator(int column_id)
        {
            List<Elevator> CustomerElevator = new List<Elevator>();
            var elevatorlist = await _context.elevators.ToListAsync();

            foreach (Elevator elevator in elevatorlist)
            {
                if (elevator.column_id == column_id)
                {
                    CustomerElevator.Add(elevator);

                }
            }
            return CustomerElevator;
        }



        // PUT: api/Elevators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        {
            if (id != elevator.Id)
            {
                return BadRequest();
            }

            _context.Entry(elevator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
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
        [HttpPatch("online/{id}")]
        public async Task<string> UpdateOnline(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);
            Console.WriteLine(elevator.status);
            if (elevator == null)
            {
                return "Please enter an existing elevator id";
            }
            if (elevator.status != "Offline" && elevator.status != "Intervention")
            {
                return "The Elevator you chose doesn't have a status of Intervention or Offline";
            }
            else
            {
                elevator.status = "Online";

                // DateTime InterventionStartTime = DateTime.Now;
                // elevator.intervention_start_date_time = InterventionStartTime;

                _context.elevators.Update(elevator);
                await _context.SaveChangesAsync();
                return "The elevator #" + elevator.Id + " status has been successufully changed to Online";
            }
        }

        // POST: api/Elevators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        {
            _context.elevators.Add(elevator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetElevator), new { id = elevator.Id }, elevator);
        }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);
            if (elevator == null)
            {
                return NotFound();
            }

            _context.elevators.Remove(elevator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElevatorExists(long id)
        {
            return _context.elevators.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly InterventionContext _context;

        public InterventionsController(InterventionContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        [HttpGet("PendingInterventions")]
        public async Task<List<Intervention>> GetPendingInterventions(long id)
        {
            List<Intervention> PendingInterventions = new List<Intervention>();

            var interventionlist = await _context.interventions.ToListAsync();

            foreach (Intervention intervention in interventionlist)
            {
                if (intervention.status_opt == "Pending")
                {
                    PendingInterventions.Add(intervention);
                }
            }
            return PendingInterventions;
        }

        [HttpPatch("online/{id}")]
        public string UpdateOnline(long id)
        {
            var interv = _context.interventions.Find(id);
            if (interv == null)
            {
                return "Please enter an existing Intervention, Pending or inPprogress id";
            }
            if (interv.status_opt != "Pending" | interv.status_opt != "Intervention" | interv.status_opt != "inProgress")
            {
                return "The Intervention you chose doesn't have a status of Intervention, Pending or inPprogress";
            }
            else
            {
                interv.status_opt = "Online";

                DateTime InterventionStartTime = DateTime.Now;
                interv.intervention_start_date_time = InterventionStartTime;

                _context.interventions.Update(interv);
                _context.SaveChanges();
                return "The intervention #" + interv.id + " status has been successufully changed Online";
            }
        }
        [HttpPatch("inprogress/{id}")]
        public string UpdateInProgress(long id)
        {
            var interv = _context.interventions.Find(id);
            if (interv == null)
            {
                return "Please enter an existing intervention id";
            }
            if (interv.status_opt != "Pending")
            {
                return "The Intervention you chose doesn't have a status of Pending";
            }
            else
            {
                interv.status_opt = "InProgress";

                DateTime InterventionStartTime = DateTime.Now;
                interv.intervention_start_date_time = InterventionStartTime;

                _context.interventions.Update(interv);
                _context.SaveChanges();
                return "The intervention #" + interv.id + " status has been successufully changed to In Progress";
            }
        }
        [HttpPost]
        public async Task<ActionResult<Intervention>> PostBuilding(Intervention intervention)
        {
            _context.interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntervention), new { id = intervention.id }, intervention);
        }

        [HttpPatch("completed/{id}")]
        public string UpdateCompleted(long id)
        {
            var interv = _context.interventions.Find(id);
            if (interv == null)
            {
                return "Please enter an existing intervention id";
            }
            if (interv.status_opt != "InProgress")
            {
                return "The Intervention you chose doesn't have a status of in progress";
            }
            else
            {
                interv.status_opt = "Completed";

                DateTime InterventionCompletionTime = DateTime.Now;
                interv.intervention_end_date_time = InterventionCompletionTime;

                _context.interventions.Update(interv);
                _context.SaveChanges();
                return "Intervention #" + interv.id + " status has been successufully changed to Completed";
            }
        }
        private bool InterventionExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }
    }
}

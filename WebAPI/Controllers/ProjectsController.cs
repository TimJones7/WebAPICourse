using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PlatformDemo.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext _db;

        public ProjectsController(BugsContext db)
        {
            this._db = db;
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
        }


        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _db.Projects.Find(id);
            
            if(project is null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                new {id = project.ProjectId},
                project
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _db.Entry(project).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Projects.Find(id) is null)
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var project = _db.Projects.Find(id);
            
            if(project is null)
            {
                return NotFound();
            }
            _db.Projects.Remove(project);
            _db.SaveChanges();
            return Ok(project);
        }

        /// <summary>
        /// api/projects/{pid}/tickets?tid={tid}
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        ///
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTickets(int pId)
        {
            var tickets = _db.Tickets.Where(t => t.ProjectId == pId).ToList();
            if (tickets is null || tickets.Count <= 0)
            {
                return NotFound();
            }
            return Ok(tickets);
        }

        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]
        //public IActionResult GetProjectTickets( [FromQuery] Ticket ticket)  //we have to specify from query, because complex datatype will look in the body for the information 
        //{

        //    if(ticket == null)
        //    {
        //        return BadRequest("Parameters are not provided properly");
        //    }

        //    if (ticket.Id == 0)
        //    {
        //        return Ok($"Reading all the tickets that belong to project {ticket.ProjectId}");
        //    }

        //    return Ok($"Reading project: {ticket.ProjectId} with ticket number: {ticket.Id}.");
        //}
    }
}

using Microsoft.AspNetCore.Mvc;


namespace PlatformDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the projects.");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Reading project id: {id}.");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Creating a project.");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Updating a project.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting project id: {id}.");
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
        public IActionResult GetProjectTickets(int pId, [FromQuery] int tid)
        {
            if (tid == 0)
            {
                return Ok($"Reading all the tickets that belong to project {pId}");
            }

            return Ok($"Reading project: {pId} with ticket number: {tid}.");
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

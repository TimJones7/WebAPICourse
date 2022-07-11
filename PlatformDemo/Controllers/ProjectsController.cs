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
            if(tid == 0)
            {
                return Ok($"Reading all the tickets that belong to project {pId}");
            }
            
            return Ok($"Reading project: {pId} with ticket number: {tid}.");
        }






    }
}

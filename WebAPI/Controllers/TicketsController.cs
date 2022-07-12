using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;



namespace PlatformDemo.Controllers
{
    //  Decorate the class to define as API not mvc controller
    //  ControllerBase provides base controller functionality without views
    [ApiController]
    [Route("api/[controller]")] //Attribute routing on the controller 
    public class TicketsController : ControllerBase
    {
        private readonly BugsContext _db;

        public TicketsController(BugsContext db)
        {
            this._db = db;
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
        }

        

        [HttpGet]
        public IActionResult Get()
        { 
            return Ok(_db.Tickets.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Reading ticket id: {id}.");
        }

        [HttpPost]
        [Route("/api/v1/tickets")]
        public IActionResult CreateV1([FromBody] Ticket ticket)
        {
            return Ok(ticket); //This will automatically serialize object to json
        }

       



        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Updating a ticket.");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket id: {id}.");
        }




    }
}

using Core.Models;
using Microsoft.AspNetCore.Mvc;



namespace PlatformDemo.Controllers
{
    //  Decorate the class to define as API not mvc controller
    //  ControllerBase provides base controller functionality without views
    [ApiController]
    [Route("api/[controller]")] //Attribute routing on the controller 
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //  Authentication and Authorization
            
            //  Generic Validation
            
            //  Retrieve the Input Data
            
            //  Data Validation
            
            //  Application Logic -> the core biz logic
            
            //  Format Output Data -> what is sent back
            
            //  Exception Handling
                  
            
            return Ok("Reading all the tickets.");
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

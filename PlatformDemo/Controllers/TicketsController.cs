﻿using Microsoft.AspNetCore.Mvc;

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
            return Ok("Reading all the tickets.");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Reading ticket id: {id}.");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Creating a ticket.");
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
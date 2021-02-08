using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonenWeb.Models;
using PersonenWeb.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonenController : ControllerBase
    {

        private IPersonenService Service { get; }
        public PersonenController(IPersonenService service)
        {
            Service = service;
        }
        
        
        
        // GET: api/<PersonenController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<IEnumerable<Person>> GetAll([FromQuery]string vorname="Erika", [FromQuery] string nachname = "Schmidt")
        {
            return Ok(Service.FindeAlle());
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<Person> GetById(string id)
        {
            Person retval = Service.FindePersonMitId(id);
            if (retval == null)
                return NotFound();
            
            return Ok(retval);
        }

        
        
        // Post als Get-Ersatz
        [HttpPost("nachname/to-upper")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]

        public ActionResult<Person> ToUpper([FromBody] Person person)
        {
            if (person.Id == "123")
                return NotFound();

            person.Nachname = person.Nachname.ToUpper();

            return Ok(person);
        }

        // Post als nicht idempotente Änderung
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Person))]
        
        public IActionResult speichern([FromBody] Person person)
        {
            person.Id = Guid.NewGuid().ToString();

            // Speichern

            return CreatedAtAction(nameof(GetById), new {id = person.Id}, person);
        }

        // Put als idempotente Änderung
        [HttpPut()]
        [Consumes(MediaTypeNames.Application.Json)]
        //[Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult speichernIdempotent([FromBody] Person person)
        {
            bool result = Service.SpeichernOderAendern(person);
            //person.Id = Guid.NewGuid().ToString();

            // Speichern mit Service
            if (result)
            {
                return Ok();
            }
            

            return Created(nameof(GetById), new { id = person.Id });
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Loeschen(string id)
        {
            bool deleted = Service.Loeschen(id);
            // Löschen mit Service
            if (deleted)
                return Ok();

            return NotFound();
        }



    }
}
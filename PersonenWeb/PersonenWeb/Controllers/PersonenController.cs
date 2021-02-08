using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using PersonenWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonenController : ControllerBase
    {
        // GET: api/<PersonenController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<Person> GetAll()
        {
            return new Person[]
            {
                new Person{Id="123",Vorname = "Erika", Nachname = "Mustermann"}, 
                new Person { Id = "234", Vorname = "John", Nachname = "Doe" }
            };
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public Person GetById(string id)
        {
            return new Person {Id = id, Vorname = "Erika", Nachname = "Mustermann"};
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazorPagesMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoeController : Controller
    {
        // GET: api/<JoeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JoeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("/myIndex")]
        public ActionResult MyIndex()
        {

            return View();

        }



        // POST api/<JoeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JoeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JoeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

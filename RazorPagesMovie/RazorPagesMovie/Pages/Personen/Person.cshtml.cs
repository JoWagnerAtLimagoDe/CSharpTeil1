using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Personen
{
    public class PersonModel : PageModel
    {

        public PersonModel()
        {
            Person = new Person {Id = "123", Vorname = "John", Nachname = "Doe"};
        }
        [BindProperty]
        public Person Person { get; set; }
        
        public void OnGet()
        {
            Console.WriteLine("Hallo");

          // Danach gehts weiter zur Seite = return Page()
        }

        public void OnPost(String action)
        {

            Console.WriteLine(action);
            Console.WriteLine("Nach Post");
            Console.WriteLine(Person);
            // Danach gehts weiter zur Seite = return Page()
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Joe
{
    public class JoeModel : PageModel
    {

        public JoeModel()
        {
            Person = new Person {Id = Guid.NewGuid().ToString(), Vorname = "John", Nachname = "Doe"};
        }
        
        public Person Person { get; set; }
        public void OnGet()
        {
            //return RedirectToPage("../Movies/Index");
        }

        public IActionResult OnPostJane()
        {

            return RedirectToPage();
        }

        public void OnPostWayne()
        {
            ViewData["jw"] = "Es geht";
            Person.Nachname = "Wayne";
           
        }

        public IActionResult Jane()
        {
            Person.Vorname = "Jane";
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LangerMann.Models;
using LangerMann.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LangerMann.Pages.Personen
{
    public class IndexModel : PageModel
    {
        //Schritt 1
        private IPersonenService Service { get;  }
        
        
        
        // Schritt 2
        public IList<Person> Personen { get; set; }
        
        
        public IndexModel(IPersonenService service)
        {
            Service = service;
        }
        
        
        // Schritt 3 populate Data
        public void OnGet()
        {
            Personen = Service.FindeAlle();
        }
    }
}

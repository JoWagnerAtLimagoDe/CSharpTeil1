using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Entities;
using WebShop.Repositories;

namespace WebShop.Pages.Bestellungen
{
    public class IndexModel : PageModel
    {
        private readonly IBestellungenRepository repository; // normalerweise Service

        public IList<TblBestellung> Bestellungen { get; set; } // normalerweise BestellungDto

        public IndexModel(IBestellungenRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            Bestellungen = repository.GetAll().ToList();
        } // normalerweise hier auch Test First

    }
}
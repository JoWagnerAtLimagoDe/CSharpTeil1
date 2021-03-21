using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.Entities;
using WebShop.Services;

namespace WebShop.Pages.Bestellungen
{
    public class CreateModel : PageModel
    {
        private readonly IBestellService service;

        [BindProperty]
        public TblBestellung Bestellung { get; set; } // normalerweise BestellungDto

        public CreateModel(IBestellService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            Bestellung = new TblBestellung
            {
                Id = Guid.NewGuid().ToString()
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            switch (service.ErfasseBestellung(Bestellung))
            {
                case BestellStatus.Rechnung: return RedirectToPage("./Rechnung");
                case BestellStatus.Nachnahme: return RedirectToPage("./Nachnahme");
                case BestellStatus.NichtLieferbar: return RedirectToPage("./NichtLieferbar");
                default: return Page();
            }

            // normalerweise auch in try-catch-Block
        }
    }
}
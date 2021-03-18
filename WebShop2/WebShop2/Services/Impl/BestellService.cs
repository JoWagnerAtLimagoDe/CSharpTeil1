using System;
using WebShop.Entities;
using WebShop.Repositories;

namespace WebShop.Services.Impl
{
    public class BestellService : IBestellService
    {
        private readonly IBestellungenRepository repository;
        private readonly IBonitaetsService bonitaetsService;
        private readonly IVerfuegbarkeitsService verfuegbarkeitsService;

        public BestellService(IBestellungenRepository repository, IBonitaetsService bonitaetsService, IVerfuegbarkeitsService verfuegbarkeitsService)
        {
            this.repository = repository;
            this.bonitaetsService = bonitaetsService;
            this.verfuegbarkeitsService = verfuegbarkeitsService;
        }

        public BestellStatus ErfasseBestellung(TblBestellung bestellung)
        {
            if (bestellung == null) throw new BestellServiceException("Parameter darf nicht null sein.");
            if (bestellung.Kundennummer % 3 != 0) return BestellStatus.Ungueltige_Kundennummer;
            throw new NotImplementedException();
        }
    }
}

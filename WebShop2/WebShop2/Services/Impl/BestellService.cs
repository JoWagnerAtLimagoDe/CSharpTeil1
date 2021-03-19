using NLog;
using System;
using System.Transactions;
using WebShop.Entities;
using WebShop.Repositories;

namespace WebShop.Services.Impl
{
    public class BestellService : IBestellService
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
            try
            {
                return ErfasseBestellungImpl(bestellung);                         
            }
            catch (BestellServiceException e)
            {
                logger.Error(e); // in catch-Block immer loggen!
                throw e;
            }
            catch (TimeoutException e)
            {
                BestellServiceException be = new BestellServiceException("Lager antwortet nicht.", e);
                logger.Error(be);
                throw be;
            }
            catch (ArithmeticException e)
            {
                throw new BestellServiceException("S&P antwortet nicht.", e);
            }
            catch (Exception e)
            {
                throw new BestellServiceException("Problem im aufgerufenen Service.", e);
            }          
        }

        private BestellStatus ErfasseBestellungImpl(TblBestellung bestellung)
        {
            Validierung(bestellung);
            BestellStatus retval = FachlichePruefung(bestellung);
            SpeichereInRepository(bestellung, retval);
            return retval;
        }

        private static void Validierung(TblBestellung bestellung)
        {
            if (bestellung == null)
                throw new BestellServiceException("Parameter darf nicht null sein.");
            if (bestellung.Kundennummer % 3 != 0)
                throw new BestellServiceException("Ungültige Kundennummer.");
        }

        private BestellStatus FachlichePruefung(TblBestellung bestellung)
        {
            BestellStatus retval = BestellStatus.Rechnung;
            if (!verfuegbarkeitsService.IsAvailable(bestellung.Produkt))
            {
                retval = BestellStatus.NichtLieferbar;
            }
            else if (!bonitaetsService.IsSolvent(bestellung.Kundennummer))
            {
                retval = BestellStatus.Nachnahme;
            }
            return retval;
        }

        private void SpeichereInRepository(TblBestellung bestellung, BestellStatus retval)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bestellung.Status = Enum.GetName(typeof(BestellStatus), retval);
                repository.Insert(bestellung);
                repository.Save(); // schlechtes Repo-Design!?
                scope.Complete();
            }
        }
    }
}

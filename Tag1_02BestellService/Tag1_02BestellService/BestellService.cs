using System;
using System.Collections.Generic;
using System.Text;
using Tag1_02BestellService.Dependecies;

namespace Bundesbank.Services
{
    public class BestellService
    {
        private SolvenzService SolvenzService { get; }
        private BestellRepository BestellRepository { get; }

        public BestellService(SolvenzService solvenzService, BestellRepository bestellRepository)
        {
            SolvenzService = solvenzService;
            BestellRepository = bestellRepository;
        }


        /*
         * Bestellung darf nicht null sein -> BestellServiceException
         * creditCard darf nicht null sein -> BestellServiceException
         * saldo darf nicht negativ sein -> BestellServiceException
         * 
         * CreditKarte zu Kurz, zu lang, falsches Format -> BestellserviceException
         * Problem in underlying Service -> BestellserviceException
         * Kunde ist pleite -> BestellserviceException
         * Happy Day
         */
        public void Speichern(Bestellung bestellung , string creditCard /* M oder V gefolgt von genau 10 Ziffern */, double saldo)
        {

        }
    }
}

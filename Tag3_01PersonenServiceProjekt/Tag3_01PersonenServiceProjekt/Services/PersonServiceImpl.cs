using Bundesbank.Repositories;
using Bundesbank.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tag3_01PersonenServiceProjekt.Services
{
    public class PersonServiceImpl
    {

        public IPersonRepository Repo { get;  }

        public PersonServiceImpl(IPersonRepository repo)
        {
            Repo = repo;
        }


        /*
         * Person darf nicht null sein ->PersonenServiceException
         * Vorname darf nicht null sein ->PersonenServiceException
         * Vorname muss min. 2 Zeichen ->PersonenServiceException
         * Nachname darf nicht null sein ->PersonenServiceException
         * Nachname muss min. 2 Zeichen ->PersonenServiceException
         * Vorname darf nicht Attila sein
         * 
         * Mock: Wenn das Speichern im Repo scheitert->Exception fangen und in PSE wandeln
         * Mock: HappyDay Verfify
        */
        public void Speichern(Person person)
        {
            if (person == null)
                throw new PersonServiceException("Person must not be null");
            if (person.Vorname == null)
                throw new PersonServiceException("Firstname too short");


        }


    }
}

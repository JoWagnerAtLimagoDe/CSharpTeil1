using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LangerMann.Models;
using LangerMann.Repositories;

namespace LangerMann.Services
{
    public class PersonenService: IPersonenService
    {
        private PersonenRepository Repository { get; }

        public PersonenService(PersonenRepository personenRepository)
        {
            Repository = personenRepository;
        }

        public bool Speichern(Person person)// SaveOrUpdate
        {
            bool retval;
            Person p = Repository.GetById(person.PersonId);
            if (p == null)
            {
                Repository.Insert(person);
                retval = true;
            }
            else
            {
                Repository.Update(person);
                retval = false;
            }
            Repository.Save();
            return retval;


        }

        public bool Loschen(Person person)
        {
            return Loschen(person.PersonId);
        }

        public bool Loschen(Guid id)
        {
            bool retval;
            Person p = Repository.GetById(id);
            if (p == null)
            {
                retval = false;
            }
            else
            {
                Repository.Delete(id);
                retval = true;
            }
            Repository.Save();
            return retval;
        }

        public IList<Person> FindeAlle()
        {
            throw new NotImplementedException();
        }

        public Person FindeMitId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

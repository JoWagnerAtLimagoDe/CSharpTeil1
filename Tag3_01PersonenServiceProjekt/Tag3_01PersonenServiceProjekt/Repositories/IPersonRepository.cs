using Bundesbank.Repositories.Models;
using System;
using System.Collections.Generic;

namespace Bundesbank.Repositories
{
    public interface IPersonRepository
    {
        public void Save(Person person);
        public void Update(Person person);
        public void Remove(Person person);
        public void Remove(String id);

        public Person FindById(string id);
        public IList<Person> FindAll();

        public IList<Person> FindByNachname(string nachname);


    }
}

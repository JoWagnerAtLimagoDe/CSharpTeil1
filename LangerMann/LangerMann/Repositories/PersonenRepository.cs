using LangerMann.Data;
using LangerMann.Models;
using System;
using System.Collections.Generic;

namespace LangerMann.Repositories
{
    public class PersonenRepository: CrudRepository<Person>, IPersonenRepository
    {
        public PersonenRepository(BundesbankContext context) : base(context)
        {
        }

        public IList<Person> FindByNachname(string nachname)
        {
            throw new NotImplementedException();
        }
    }
}

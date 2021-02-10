using LangerMann.Models;
using System.Collections.Generic;

namespace LangerMann.Repositories
{
    public interface IPersonenRepository: ICrudRepository<Person>
    {
        IList<Person> FindByNachname(string nachname);
    }
} 

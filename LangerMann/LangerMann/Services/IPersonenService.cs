using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LangerMann.Models;

namespace LangerMann.Services
{
    public interface IPersonenService
    {
        bool Speichern(Person person);
        bool Loschen(Person person);
        bool Loschen(Guid id);

        IList<Person> FindeAlle();
        Person FindeMitId(Guid id);
    }
}

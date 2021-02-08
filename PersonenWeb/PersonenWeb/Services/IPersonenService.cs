using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonenWeb.Models;

namespace PersonenWeb.Services
{
    public interface IPersonenService
    {
        bool SpeichernOderAendern(Person person);
        bool Loeschen(string id);

        Person FindePersonMitId(string id);

        IEnumerable<Person> FindeAlle();

    }
}

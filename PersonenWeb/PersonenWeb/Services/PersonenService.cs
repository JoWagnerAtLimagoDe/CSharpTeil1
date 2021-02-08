using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonenWeb.Models;

namespace PersonenWeb.Services
{
    public class PersonenService:IPersonenService
    {
        public bool SpeichernOderAendern(Person person)
        {
            return true;
        }

        public bool Loeschen(string id)
        {
            return true;
        }

        public Person FindePersonMitId(string id)
        {
            return new Person {Id = id, Vorname = "Max", Nachname = "Doe"};
        }

        public IEnumerable<Person> FindeAlle()
        {
            return new Person[] { new Person { Id = "1234", Vorname = "Max", Nachname = "Doe"}, new Person { Id = "12345", Vorname = "Max", Nachname = "Doe" }};
             
            
        }
    }
}

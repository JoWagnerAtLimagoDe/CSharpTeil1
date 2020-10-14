using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Repositories.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public Person()
        {
            Id = null;
            Vorname = "John";
            Nachname = "Doe";
        }
        public Person(string vorname, string nachname)
        {
            Id = null;
            Vorname = vorname;
            Nachname = nachname;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionUebung
{
    public class Person
    {
       
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public Person():this("John","Doe")
        {

        }

        public Person(string vorname, string nachname)
        {
            Vorname = vorname;
            Nachname = nachname;
        }

        public override string ToString() => $"{Vorname} {Nachname}";
    }

}

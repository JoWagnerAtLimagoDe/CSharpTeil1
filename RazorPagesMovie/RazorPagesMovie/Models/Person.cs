using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Vorname)}: {Vorname}, {nameof(Nachname)}: {Nachname}";
        }
    }
}

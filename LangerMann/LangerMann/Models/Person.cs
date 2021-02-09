using System;
using System.ComponentModel.DataAnnotations;

namespace LangerMann.Models
{
    public class Person
    {
        public Person()
        {

        }

        public override string ToString() => $"{nameof(PersonId)}: {PersonId}, {nameof(Vorname)}: {Vorname}, {nameof(Nachname)}: {Nachname}";


        [Key]
        public Guid PersonId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

      
    }
}

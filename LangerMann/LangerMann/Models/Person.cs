using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LangerMann.Models
{
    public class Person
    {
  
       [Key]
       [Required]
       public Guid PersonId { get; set; }

        
        [StringLength(30)]
        [Required]
        public string Vorname { get; set; }
        
        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Nachname { get; set; }
        
        public override string ToString() => $"{nameof(PersonId)}: {PersonId}, {nameof(Vorname)}: {Vorname}, {nameof(Nachname)}: {Nachname}";

    }
}

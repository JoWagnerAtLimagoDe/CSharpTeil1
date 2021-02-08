using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonenWeb.Models
{
    public class Person
    {
        public string Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Vorname { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Nachname { get; set; }
    }
}

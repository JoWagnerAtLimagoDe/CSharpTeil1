using System;
using System.Collections.Generic;

namespace WebShop.Entities
{
    public partial class TblBestellung
    {
        public string Id { get; set; }
        public int Kundennummer { get; set; }
        public string Produkt { get; set; }
        public string Status { get; set; }
        public byte[] Rowversion { get; set; }
    }
}

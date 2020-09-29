using Bundesbank.Mitarbeiter.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter
{
    public class Gehaltsempfaenger:AbstractMitarbeiter
    {
        public double Gehalt { get; set; }

        public Gehaltsempfaenger(String name) : base(name)
        {
            Gehalt = 1000;
        }

        public override string ToString()
        {
            return "Gehaltsempänger Name=" + Name + ", Gehalt=" + Gehalt;
        }

        public override void accept(MitarbeiterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

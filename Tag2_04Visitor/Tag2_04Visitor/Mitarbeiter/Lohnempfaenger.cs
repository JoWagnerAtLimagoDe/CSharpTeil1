using Bundesbank.Mitarbeiter;
using Bundesbank.Mitarbeiter.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter
{
    public class Lohnempfaenger: AbstractMitarbeiter
    {
        public double Stundenlohn { get; set; }
        public double  Arbeitszeit { get; set; }
        public Lohnempfaenger(String name=""):base(name)
        {
            Stundenlohn = 10;
            Arbeitszeit = 40;
        }
        public override string ToString()
        {
            return "Lohnempfänger Name=" + Name + " StundeLohn=" + Stundenlohn + ", Arbeitszeit=" + Arbeitszeit;
        }

        public override void accept(MitarbeiterVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

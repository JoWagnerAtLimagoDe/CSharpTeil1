using Bundesbank.Mitarbeiter;
using Bundesbank.Mitarbeiter.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Firma
{
    public class Firma
    {
        public IList<AbstractMitarbeiter> Mitarbeiters { get; set; }
        public Firma()
        {
            Mitarbeiters = new List<AbstractMitarbeiter>();
        }

        public void print()
        {
            foreach(AbstractMitarbeiter mitarbeiter in Mitarbeiters)
            {
                Console.WriteLine(mitarbeiter);
            }
        }

        public void iterate(MitarbeiterVisitor visitor)
        {
            foreach (AbstractMitarbeiter mitarbeiter in Mitarbeiters)
            {
                // visitor.Visit(mitarbeiter);
                mitarbeiter.accept(visitor);
            }
        }
    }
}

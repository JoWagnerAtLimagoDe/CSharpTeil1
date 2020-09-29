using Bundesbank.Mitarbeiter.Visitors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter
{
    public abstract class AbstractMitarbeiter
    {
        public String Name { get; set; }

        public AbstractMitarbeiter(String name = "Nobody")
        {
            Name = name;
        }

        public override String ToString()
        {
            return "Mitarbeiter Name=" + Name;
        }

        public abstract void accept(MitarbeiterVisitor visitor);
    }
}

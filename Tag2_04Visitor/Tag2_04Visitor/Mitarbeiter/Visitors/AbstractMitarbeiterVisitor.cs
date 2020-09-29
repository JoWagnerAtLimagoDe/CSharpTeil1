using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter.Visitors
{
    public abstract class AbstractMitarbeiterVisitor : MitarbeiterVisitor
    {
        public void Visit(Gehaltsempfaenger gehaltsempfaenger)
        {
            
        }

        public void Visit(Lohnempfaenger lohnempfaenger)
        {
            
        }
    }
}

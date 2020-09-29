using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter.Visitors
{
    public interface MitarbeiterVisitor
    {
        void Visit(Gehaltsempfaenger gehaltsempfaenger);
        void Visit(Lohnempfaenger lohnempfaenger);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Mitarbeiter.Visitors
{
    public class PrintVisitor : MitarbeiterVisitor
    {
        public void Visit(Gehaltsempfaenger gehaltsempfaenger)
        {
            Console.WriteLine(gehaltsempfaenger);
        }

        public void Visit(Lohnempfaenger lohnempfaenger)
        {
            Console.WriteLine(lohnempfaenger);
        }
    }
}

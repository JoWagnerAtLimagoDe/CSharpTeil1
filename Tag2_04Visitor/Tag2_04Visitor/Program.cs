using Bundesbank.Firma;
using Bundesbank.Mitarbeiter;
using Bundesbank.Mitarbeiter.Visitors;
using System;

namespace Tag2_04Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Firma firma = new Firma();
            firma.Mitarbeiters.Add(new Gehaltsempfaenger("Schmidt"));
            firma.Mitarbeiters.Add(new Lohnempfaenger("Hinz"));
            firma.Mitarbeiters.Add(new Lohnempfaenger("Kunz"));
            firma.Mitarbeiters.Add(new Gehaltsempfaenger("Mayer"));
            firma.Mitarbeiters.Add(new Gehaltsempfaenger("Schulz"));

            //firma.print();
            firma.iterate(new PrintVisitor());
            firma.iterate(new ResetArbeitszeitVisitor());
            firma.iterate(new PrintVisitor());
        }
    }
}

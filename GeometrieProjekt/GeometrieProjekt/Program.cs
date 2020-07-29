using Bundesbank.Geometrie;
using System;

namespace GeometrieProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Object ob;
            Punkt p;
            Kreis k;

            k = new Kreis();
            p = k;
            ob = k;
            Console.WriteLine(ob);

            

        }
    }
}

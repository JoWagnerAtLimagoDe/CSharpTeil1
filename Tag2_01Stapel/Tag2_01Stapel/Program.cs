using Bundesbank.Collections;
using Bundesbank.Geometrie;
using de.bundesbank.tiere;
using System;

namespace Tag2_01Stapel
{
    class Program
    {
        static void Main(string[] args)
        {
            Stapel<Punkt> myStapel = new Stapel<Punkt>(40);
           
            for (int i = 0; i < 10; i++)
            {
                if(!myStapel.IsFull)
                {
                    //myStapel.Push(new Schwein("Schwein Nr." + i));
                    myStapel.Push(new Punkt(i,i));
                    myStapel.Push(new Kreis( i));
                    //myStapel.Push(i);
                }
            }
            
            while (!myStapel.IsEmpty)
            {
                Punkt p = myStapel.Pop();
                p.Rechts();
                Console.WriteLine(p);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace de.bundesbank.tiere
{
    public class Schwein
    {
        public static int Counter { get; private set; }

        public string Name { get; set; }
        public int Gewicht { get; private set; }

        // Der Instantz-Konstruktor (Initialisiert das Objekt)
        // D.h. wird durch den "new"-Operator aufgerufen bei jeder Erzeugung eines Objektes
        // Aufgabe ist ALLE Eigenschaften mit sinnvollen Startwerten zu belegen
        //public Schwein():this("Nobody")
        //{
            
        //}
        public Schwein(string name = "Nobody")
        {
            this.Name = name;
            this.Gewicht = 10;
        }
        // Klassenkonstruktor
        // Intitialisiert die Klassenvariablen
        static Schwein()
        {
            Schwein.Counter = 0;
        }

        ~Schwein()
        {
               Console.WriteLine("Quiiiiek");
        }
       
        public void Fressen()
        {
            this.Gewicht++;
        }

        public override string ToString()
        {
            return $"Dieses Schwein heißt {this.Name} und wiegt {this.Gewicht}.";
        }
    }
}

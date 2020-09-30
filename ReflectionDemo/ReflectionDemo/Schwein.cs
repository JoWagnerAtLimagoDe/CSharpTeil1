using System;
using System.Collections.Generic;
using System.Text;

namespace Tiere
{
    public class Schwein
    {
        

        public string Name { get; set; }

        private int gewicht;
        public int Gewicht
        {
            get => gewicht;
            set => gewicht = value;
        }

        public Schwein():this("Nobody")
        {
        }

        public Schwein(string name)
        {
            Name = name;
            Gewicht = 10;
        }

        private void Fressen()
        {
            Gewicht++;
        }

        public override string ToString() => $"Dieses Schwein heißt {Name} und wiegt {Gewicht}.";

       
    }
}

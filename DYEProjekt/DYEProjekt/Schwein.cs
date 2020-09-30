using DYEProjekt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tiere
{
    public class Schwein
    {
        public delegate void SchweinHandler(Schwein schwein);

       
        
        public event SchweinHandler PigTooFatEvent;
        //public event EventHandler AnyEvent;

        public string Name { get; set; }

        private int gewicht;
        public int Gewicht
        {
            get => gewicht;
            set { gewicht = value;
                //AnyEvent?.Invoke(this, new EventArgs());
                if (gewicht >= 20) PigTooFatEvent?.Invoke(this);
            }
        }

        public Schwein() : this("Nobody")
        {
        }

        public Schwein(string name)
        {
            Name = name;
            Gewicht = 10;
        }

        public void Fressen()
        {
            Gewicht++;
        }

        public override string ToString() => $"Dieses Schwein heißt {Name} und wiegt {Gewicht}.";


    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Geometrie
{
    public class Punkt:Object
    {
        private const double MAX = 10.0;
        private double x;
        public double X { 
            get { return x; } 
            private set {
                if (value < -MAX) value = -MAX;
                if (value > MAX) value = MAX;
                x = value; 
            } 
        }

        private double y;
        public double Y { get { return y; } 
            private set {
                if (value < -MAX) value = -MAX;
                if (value > MAX) value = MAX;
                y = value; 
            } 
        }


        public Punkt():this(0,0)
        {
           
        }

        public Punkt(double x, double y)
        {
            X = x;
            Y = y;
            
        }

        public override string ToString()
        {
            return base.ToString() + $" Punkt: X={X}, Y={Y}";
        }

        //public void Rechts()
        //{
        //    Rechts(1.0);
        //}
        public virtual void Rechts(double schrittweite = 1.0) // Überladen
        {
            X+= schrittweite;
        }

        public void Links()
        {
            X--;
        }
        public void Oben()
        {
            Y++;
        }
        public void Unten()
        {
            Y--;
        }


    }
}

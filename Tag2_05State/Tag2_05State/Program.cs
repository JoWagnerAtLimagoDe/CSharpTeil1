using System;
using Tag2_05State.State;

namespace Tag2_05State
{
    class Program
    {
        static void Main(string[] args)
        {
            Blende blende = new Blende();
            blende.Print();
            blende.ChangeToB();
            blende.Print();
            blende.ChangeToB();
        }
    }
}

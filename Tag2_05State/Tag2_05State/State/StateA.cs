using System;
using System.Collections.Generic;
using System.Text;

namespace Tag2_05State.State
{
    public class StateA : AbstractState
    {
        public StateA(Blende blende) : base(blende)
        {
        }

        public override void ChangeToB()
        {
            Blende.current = Blende.stateB;
        }

        public override void Print()
        {
            Console.WriteLine("Hier druckt A");
        }

    }
}

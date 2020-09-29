using System;
using System.Collections.Generic;
using System.Text;

namespace Tag2_05State.State
{
    public class StateB : AbstractState
    {
        public StateB(Blende blende) : base(blende)
        {
        }


        public override void ChangeToA()
        {
            Blende.current = Blende.stateA;
        }

        public override void Print()
        {
            Console.WriteLine("Hier druckt B");
        }
    }
}

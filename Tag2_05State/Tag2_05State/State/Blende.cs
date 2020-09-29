using System;
using System.Collections.Generic;
using System.Text;

namespace Tag2_05State.State
{
    public class Blende
    {
        internal readonly State stateA;
        internal readonly State stateB;

        internal State current;

        public Blende()
        {
            stateA = new StateA(this);
            stateB = new StateB(this);
            current = stateA;
        }

        public virtual void ChangeToA()
        {
            current.ChangeToA();
        }

        public virtual void ChangeToB()
        {
            current.ChangeToB();
        }

        public virtual void Print()
        {
            current.Print();
        }
    }
   }

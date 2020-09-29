using System;
using System.Collections.Generic;
using System.Text;


namespace Tag2_05State.State
{
    public abstract class AbstractState : State
    {
       
        public Blende Blende { get; }
        public AbstractState(Blende blende)
        {
            Blende = blende;
        }


        public virtual void ChangeToA()
        {
            throw new NotSupportedException("Macht in diesem Status keinen Sinn");
        }

        public virtual void ChangeToB()
        {
            throw new NotSupportedException("Macht in diesem Status keinen Sinn");
        }

        public virtual void Print()
        {
            throw new NotSupportedException("Macht in diesem Status keinen Sinn");
        }
    }
}

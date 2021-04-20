using System;
using System.Collections.Generic;
using System.Text;

namespace EventDemo
{
    class Sender
    {
        public delegate void WagnerHandler(string s);
        
        public event EventHandler<TickCountEventArgs> OnTickOverflow;

        public event WagnerHandler MySpecialEvent;
        
        private int ticks = 0;

        public int Ticks
        {
            get
            {
                return ticks;
            }

            set
            {
                ticks = value;
                MySpecialEvent?.Invoke("Ticks changed" + Ticks);
                if(ticks> 3) fireTicksMaxReachedEvent();
            }
        }
        public void increaseTicks()
        {
            Ticks++;
        }
        
        private void fireTicksMaxReachedEvent()
        {
                 OnTickOverflow?.Invoke(this, new TickCountEventArgs(Ticks));
        }

       

        



    }
}

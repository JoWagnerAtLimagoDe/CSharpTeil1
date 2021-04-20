using System;
using System.Collections.Generic;
using System.Text;

namespace EventDemo
{
    class TickCountEventArgs:EventArgs
    {

        public int Ticks { get;  }
        public TickCountEventArgs(int ticks)
        {
            Ticks = ticks;
        }
    }
}

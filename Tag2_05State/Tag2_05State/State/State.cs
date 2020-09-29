using System;
using System.Collections.Generic;
using System.Text;

namespace Tag2_05State.State
{
    public interface State
    {
        public void Print();
        public void ChangeToA();
        public void ChangeToB();
    }
}

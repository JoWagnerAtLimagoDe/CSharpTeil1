using System;
using System.Collections.Generic;
using System.Text;

namespace Tag1_02StapelMitNUnit
{
    public class StapelException : Exception
    {
        public StapelException(string message) : base(message)
        {
        }
    }
}

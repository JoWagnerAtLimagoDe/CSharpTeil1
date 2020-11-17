using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Services

{
    public class BestellServiceException: Exception
    {
        public BestellServiceException(string message) : base(message)
        {
           
        }
    }
}

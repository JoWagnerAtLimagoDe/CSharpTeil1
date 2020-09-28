using Bundesbank.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Math
{
    public class CalculatorFactory
    {
        public static bool logger { get; set; }
        public static bool secure { get; set; }
        static CalculatorFactory()
        {
            logger = true;
            secure = true;
        }
        public static Calculator create()
        {
            Calculator calculator = new CalculatorImpl();
            if(logger) calculator = new CalculatorLogger(calculator);
            if(secure) calculator = new CalculatorSecure(calculator);
            return calculator;
        }
    }
}

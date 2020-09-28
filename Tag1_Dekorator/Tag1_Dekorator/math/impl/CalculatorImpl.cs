using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Bundesbank.Math
{
    public class CalculatorImpl : Calculator
    {
        public virtual double add(double a, double b)
        {
            return a + b;
        }
        public virtual double sub(double a, double b)
        {
            return add(a, -b);
        }
    }
}

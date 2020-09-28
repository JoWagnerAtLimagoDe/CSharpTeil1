using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Math
{
    public class CalculatorSecure:Calculator
    {
        private readonly Calculator calculator;

        public CalculatorSecure (Calculator calculator)
        {
            this.calculator = calculator;
        }

        public double add(double a, double b)
        {
            Console.WriteLine("Du kommst hier rein");
            return calculator.add(a, b);
        }

        public double sub(double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}

using Bundesbank.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Math
{
    public class CalculatorLogger: Calculator
    {
        private readonly Calculator calculator;

        public CalculatorLogger(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public virtual double add(double a, double b)
        {
            Console.WriteLine("Add wurde gerufen");
            return calculator.add(3, 4);

        }

        public double sub(double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}

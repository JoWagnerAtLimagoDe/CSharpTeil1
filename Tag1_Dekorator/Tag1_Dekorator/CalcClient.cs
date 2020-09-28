using Bundesbank.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tag1_Dekorator
{
    public class CalcClient
    {
        private readonly Calculator calculator;

        public CalcClient(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void go()
        {
              Console.WriteLine(calculator.add(3, 4));
        }
    }
}

using Bundesbank.Math;
using System;
using System.Diagnostics;
using System.Threading;


namespace Tag1_Dekorator
{
    class Program
    {
    
        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(2000);
            stopwatch.Stop();
            Console.WriteLine("Duration={0}", stopwatch.Elapsed);


            CalculatorFactory.logger = true;
            CalculatorFactory.secure = false;
            Calculator calculator = CalculatorFactory.create();
            CalcClient client = new CalcClient(calculator);
            client.go();
        }
    }
}

using Bundesbank.Collections;
using System;

namespace Tag2_01Stapel
{
    class Program
    {
        static void Main(string[] args)
        {
            Stapel myStapel = new Stapel();
            for (int i = 0; i < 10; i++)
            {
                if(!myStapel.IsFull)
                {
                    myStapel.Push(i);
                }
            }

            while (!myStapel.IsEmpty)
            {
                Console.WriteLine(myStapel.Pop());
            }
        }
    }
}

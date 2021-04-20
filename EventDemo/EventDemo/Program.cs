using System;
using System.Runtime.InteropServices;

namespace EventDemo
{
    class Program
    {
        Empfaenger e = new Empfaenger();
        static void Main(string[] args)
        {

            new Program().run();
        }

        private void run()
        {
            
            Sender s = new Sender();

            s.OnTickOverflow    += hansi;
            s.OnTickOverflow += fritzi;
            s.MySpecialEvent += myEventAdapter;

            for (int i = 0; i < 5; i++)
            {
                s.increaseTicks();
            }

            Console.WriteLine("Hello World!");
        }

        private void hansi(object? sender, TickCountEventArgs args)
        {
            e.BlaBlupp(args.Ticks);
        }

        private void fritzi(object? sender, TickCountEventArgs args)
        {

        }

        private void myEventAdapter(String value)
        {
            Console.WriteLine(value);
        }
    }
}

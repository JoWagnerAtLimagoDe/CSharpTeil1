using System;
using Tiere;

namespace DYEProjekt
{
    class Program
    {

        Metzger metzger = new Metzger();
        Spediteur spediteur = new Spediteur();
        static void Main(string[] args)
        {
            new Program().run();
        }

        private void run()
        {
            Schwein piggy = new Schwein("Miss Piggy");
            /*
            piggy.AddPigTooFatListener(metzger.schlachten);
            piggy.AddPigTooFatListener(spediteur.fahren);
            */

            //piggy.PigTooFatEvent += metzger.schlachten;
            piggy.PigTooFatEvent += spediteur.fahren;
            piggy.PigTooFatEvent += Piggy_PigTooFatEvent;

            //piggy.AnyEvent += Piggy_AnyEvent;

            for (int i = 0; i < 10; i++)
            {
                piggy.Fressen();
            }

            Console.WriteLine("Hello World!");
        }

        private void Piggy_AnyEvent(object sender, EventArgs e)
        {
            spediteur.fahren(sender);
        }

        private void Piggy_PigTooFatEvent(Schwein schwein)
        {
            metzger.schlachten();
        }
    }
   

    class Metzger 
    {
        public void schlachten()
        {
            Console.WriteLine("Messer wetz");
        }
    }

    class Spediteur
    {
        public void fahren(Object ware)
        {
            Console.WriteLine("Wir fahren auf der Autobahn");
        }
    }
}

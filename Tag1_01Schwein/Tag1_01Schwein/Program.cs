using de.bundesbank.tiere;
using System;

namespace Tag1_01Schwein
{
    class Program
    {
        static void Main(string[] args)
        {

            new Program().run();

         
        }

        public void run()
        {
            Console.WriteLine(Schwein.Counter);

            // Declaration
            Schwein piggy;
            piggy = new Schwein();



            piggy.Name = "Miss Piggy";

            Console.WriteLine(piggy);


            piggy.Fressen();

            Console.WriteLine(piggy);
        }
    }
}

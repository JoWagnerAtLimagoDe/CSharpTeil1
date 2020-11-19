using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public class HumanPlayer : AbstractTakeGamePlayer
    {
        public HumanPlayer()
        {
        }

        public HumanPlayer(string name) : base(name)
        {
        }

        public override int Turn(int stones)
        {
            Console.WriteLine ($"Es gibt {stones} Steine. Bitte nehmen Sie 1,2 oder 3");
            return Int32.Parse(Console.ReadLine());
        }
    }
}

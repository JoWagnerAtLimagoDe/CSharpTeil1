using Bundesbank.Spiele.GamePlayer;
using System;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public class HumanPlayer : AbstractPlayer<int,int>
    {
        public HumanPlayer()
        {
        }

        public HumanPlayer(string name) : base(name)
        {
        }

        public override int DoMove(int stones)
        {
            Console.WriteLine ($"Es gibt {stones} Steine. Bitte nehmen Sie 1,2 oder 3");
            return Int32.Parse(Console.ReadLine());
        }
    }
}

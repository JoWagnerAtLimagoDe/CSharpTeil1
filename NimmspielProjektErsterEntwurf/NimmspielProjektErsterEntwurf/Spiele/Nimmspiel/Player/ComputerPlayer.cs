using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public class ComputerPlayer : AbstractTakeGamePlayer
    {
        private readonly int[] zuege = { 3, 1, 1, 2 };

        public ComputerPlayer()
        {
        }

        public ComputerPlayer(string name) : base(name)
        {
        }

        public override int Turn(int stones)
        {
           
            int zug = zuege[stones % 4];
            Console.WriteLine($"Computer nimmt {zug} Steine.");
            return zug;
        }
    }
}

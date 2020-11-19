using Bundesbank.Spiele.GamePlayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public class Oma: AbstractPlayer<int, int>
    {
        private readonly int[] zuege = { 3, 1, 1, 2 };

        public Oma()
        {
        }

        public Oma(string name) : base(name)
        {
        }

        public override int DoMove(int stones)
        {
            Random random = new Random();
            return random.Next(1, 4);
           
        }
    }
}

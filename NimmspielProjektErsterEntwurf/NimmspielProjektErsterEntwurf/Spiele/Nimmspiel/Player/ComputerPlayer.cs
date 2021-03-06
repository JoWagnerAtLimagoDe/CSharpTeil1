﻿using Bundesbank.Spiele.GamePlayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public class ComputerPlayer : AbstractPlayer<int, int>
    {
        private readonly int[] zuege = { 3, 1, 1, 2 };

        public ComputerPlayer()
        {
        }

        public ComputerPlayer(string name) : base(name)
        {
        }

        public override int DoMove(int stones)
        {
           
            int zug = zuege[stones % 4];
            Console.WriteLine($"Computer nimmt {zug} Steine.");
            return zug;
        }
    }
}

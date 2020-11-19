using Bundesbank.Spiele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.ClientSide
{
    public class GameClient
    {
        private IGame Game { get; }

        public GameClient(IGame game)
        {
            Game = game;
        }

        public void go()
        {
            Game.play();
        }
    }
}

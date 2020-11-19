using Bundesbank.Spiele;
using Bundesbank.Spiele.Nimmspiel.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel
{
    public class TakeGameImpl : AbstractGame<int,int>
    {
       

        public TakeGameImpl()
        {
            Scene = 23;
        }

      
        protected override bool GameOver { get { return Scene < 1 || Players.Count == 0; } }

        protected override void CalculateScene()
        {
          
        
            Scene -= Move;
        }

        protected override bool IsMoveComplyingToTheRules()
        {
            return Move >= 1 && Move <= 3;
        }

    }
}

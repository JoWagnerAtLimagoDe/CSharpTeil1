using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public abstract class AbstractTakeGamePlayer : TakeGamePlayer
    {

        public AbstractTakeGamePlayer()
        {
            Name = this.GetType().Name;
        }

        public AbstractTakeGamePlayer(string name)
        {
            Name = name;
        }


        public virtual string Name { get; }

        public abstract int Turn(int stones);
    }
}

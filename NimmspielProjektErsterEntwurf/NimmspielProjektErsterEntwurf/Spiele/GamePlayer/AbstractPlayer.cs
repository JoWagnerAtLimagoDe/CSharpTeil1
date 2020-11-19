using Bundesbank.Spiele.GamePlayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.GamePlayer
{
    public abstract class AbstractPlayer<SCENE, MOVE> : IPlayer<SCENE, MOVE>
    {

        public AbstractPlayer()
        {
            Name = this.GetType().Name;
        }

        public AbstractPlayer(string name)
        {
            Name = name;
        }


        public virtual string Name { get; }

        public abstract MOVE DoMove(SCENE scene);
    }
}

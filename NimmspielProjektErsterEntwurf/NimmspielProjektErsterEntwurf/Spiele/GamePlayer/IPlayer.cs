using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.GamePlayer
{
    public interface IPlayer<SCENE, MOVE>
    {

        string Name { get; }
        MOVE DoMove(SCENE scene);
    }
}

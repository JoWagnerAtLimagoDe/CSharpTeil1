using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel.Player
{
    public interface TakeGamePlayer
    {
        string Name { get; }
        int Turn(int stones);
    }
}

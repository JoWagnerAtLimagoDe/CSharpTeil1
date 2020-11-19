using Bundesbank.ClientSide;
using Bundesbank.Spiele;
using Bundesbank.Spiele.Nimmspiel;
using Bundesbank.Spiele.Nimmspiel.Player;
using System;

namespace NimmspielProjektErsterEntwurf
{
    class Program
    {
        static void Main(string[] args)
        {
            TakeGameImpl game = new TakeGameImpl();
            game.AddPlayer(new HumanPlayer());
            game.AddPlayer(new ComputerPlayer());

            GameClient client = new GameClient(game);
            client.go();
        }
    }
}

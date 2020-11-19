using Bundesbank.Spiele;
using Bundesbank.Spiele.Nimmspiel.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele.Nimmspiel
{
    public class TakeGameImpl : IGame
    {
        private int Stones { get; set; }
        private bool GameOver { get { return Stones < 1 || players.Count==0; }  }

        private int zug;

        private IList<TakeGamePlayer> players = new List<TakeGamePlayer>();

        public void AddPlayer(TakeGamePlayer player)
        {
            players.Add(player);
        }


        public void RemovePlayer(TakeGamePlayer player)
        {
            players.Remove(player);
        }

        public TakeGameImpl()
        {
            Stones = 23;
            
        }

        public void play()
        {
           while ( ! GameOver )
            {
                ExcecuteTurns();
            }
        }

        private void ExcecuteTurns()
        {
            foreach (TakeGamePlayer player in players)
            {
                ExecuteTurn(player);
            }
        }

        private void ExecuteTurn(TakeGamePlayer player)
        {
            if (InitTurn(player))
                return;

            while (true)
            {
                
                zug = player.Turn(Stones);
                if (zug >= 1 && zug <= 3)
                    break;
                write("Ungültiger Zug");
            }


            TerminateTurn( player);

        }

       

       

        private bool InitTurn(TakeGamePlayer player)
        {
            write($"Player {player.Name} ist am Zug.");
            return GameOver;
        }

        private void TerminateTurn( TakeGamePlayer spieler)
        {
            CalculateBoard();
            SendMessageIfGameIsOver(spieler);
        }


        private void CalculateBoard()
        {
            Stones -= zug;
        }


        private void SendMessageIfGameIsOver(TakeGamePlayer spieler)
        {
            if (GameOver)
            {
                write($"{spieler.Name} hat verloren");

            }
        }

        private void write(string message)
        {
            Console.WriteLine(message);
        }
    }
}

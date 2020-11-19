using Bundesbank.Spiele.GamePlayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Spiele
{
    public abstract class AbstractGame<SCENE, MOVE> : IGame
    {
        protected SCENE Scene { get; set; }
        protected MOVE Move { get; set; }

        protected abstract bool GameOver { get; }

        protected abstract bool IsMoveComplyingToTheRules();

        protected abstract void CalculateScene();

        protected IList<IPlayer<SCENE, MOVE>> Players { get; } = new List<IPlayer<SCENE, MOVE>>();



        public void AddPlayer(IPlayer<SCENE, MOVE> player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(IPlayer<SCENE, MOVE> player)
        {
            Players.Remove(player);
        }

        public void play()
        {
            while (!GameOver)
            {
                ExcecuteTurns();
            }
        }

        private void ExcecuteTurns()
        {
            foreach (IPlayer<SCENE, MOVE> player  in Players)
            {
                ExecuteTurn(player);
            }
        }

        private void ExecuteTurn(IPlayer<SCENE, MOVE> player)
        {
            if (InitTurn(player))
                return;

            PerformUsersMove(player);

            TerminateTurn(player);

        }

        private bool InitTurn(IPlayer<SCENE, MOVE> player)
        {
            write($"Player {player.Name} ist am Zug.");
            return GameOver;
        }

        private void PerformUsersMove(IPlayer<SCENE, MOVE> player)
        {
            while (!MadeValidMove(player))
            {
                write("Ungültiger Zug");
            }
        }
        private void TerminateTurn(IPlayer<SCENE, MOVE> spieler)
        {
            CalculateScene();
            SendMessageIfGameIsOver(spieler);
        }

        private bool MadeValidMove(IPlayer<SCENE, MOVE> player)
        {
            Move = player.DoMove(Scene);
            return IsMoveComplyingToTheRules();
        }

        private void SendMessageIfGameIsOver(IPlayer<SCENE, MOVE> spieler)
        {
            if (GameOver)
            {
                write($"{spieler.Name} hat verloren");

            }
        }

        protected void write(string message)
        {
            Console.WriteLine(message);
        }


    }
}

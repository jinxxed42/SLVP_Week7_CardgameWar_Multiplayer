using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    internal class Game
    {
        private List<Card> _deck = new List<Card>();
        public List<Player> Players { get; private set; } = new List<Player>();

        public bool GameOver { get; private set; }

        public string GameWinner { get; private set; } = string.Empty;

        public int GameRounds { get; private set; }

        private static Random _rand = new Random();

        public void StartGame(int numPlayers)
        {
            GameOver = false;
            GameRounds = 0;
            Players.Clear(); 
            for (int i = 0; i < numPlayers; i++) 
            {
                Player p = new Player($"Player{i+1}");
                Players.Add(p);
            }
        }


        public void FillDeck()
        {
            // For every 2 players create a full main deck of cards.
            int deckSize = (int)Math.Ceiling(Players.Count / 2.0);
            _deck.Clear();
            for (int i = 0; i < deckSize; i++) 
            {
                foreach (CardSuit cSuit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardValue cValue in Enum.GetValues(typeof(CardValue)))
                    {
                        _deck.Add(new Card(cValue, cSuit));
                    }
                }
            }

            // Randomly assign cards to players.
            foreach (Player p in Players)
            {
                p.Score = 0;
                for (int i = 0; i < 26; i++) 
                { 
                    int index = _rand.Next(0, _deck.Count - 1);
                    Card c = _deck[index];
                    _deck.RemoveAt(index);
                    p.CardDeck.Enqueue(c);
                }
            }
        }

        public Card SelectCard(Player player)
        {
            return player.CardDeck.Dequeue();
        }

        public void PlayRound()
        {
            GameRounds++;
            CardValue highestValue = CardValue.Ace; // Lowest value card in this implementation, so the highest value is at least this.
            foreach (Player p in Players)
            {
                p.CardDrawn = SelectCard(p);
                if (p.CardDrawn.Value > highestValue)
                {
                    highestValue = p.CardDrawn.Value;
                }
            }

            int numPlayersWithMaxValue = 0;

            foreach (Player p in Players)
            {
                if (p.CardDrawn.Value == highestValue)
                {
                    numPlayersWithMaxValue++;
                }
            }

            // If more than one player has the highest score each gets 1 point, else the one player gets 2 points.
            if (numPlayersWithMaxValue > 1) { 
                foreach (Player p in Players)
                {
                    if (p.CardDrawn.Value == highestValue)
                    {
                        p.Score++;
                    }
                }
            }
            else
            {
                // Since there is only one player with highestValue in this case it will always find a match in the list.
                // Alert suppressed.
                Players.Find(p => p.CardDrawn.Value == highestValue)!.Score += 2;
            }

            // 26 rounds played means the game is over.
            if (GameRounds == 26)           
            {
                GameOver = true;
                int highScore = 0;
                int numWinners = 1;
                Player winner = new Player();
                // Finding the highest-scoring player(s).
                foreach (Player p in Players)
                {
                    if (p.Score > highScore)
                    {
                        highScore = p.Score;
                        numWinners = 1;
                        winner = p;
                    }
                    else if (p.Score == highScore)
                    {
                        numWinners++;
                    }
                }

                if (numWinners == 1) 
                { 
                    GameWinner = "The game is over and the winner is " + winner.Name + "!";
                }
                else
                {
                    GameWinner = "The game is over and it was a draw between " + numWinners + " players!";
                }

            }
        }

    }
}

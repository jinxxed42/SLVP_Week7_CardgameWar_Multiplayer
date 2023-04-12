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
        private List<Card> deck;
        public List<Player> players;

        public bool GameOver { get; private set; }

        public string GameWinner { get; private set; }

        public int GameRounds { get; private set; }

        private static Random _rand = new Random();

        public Game()
        {

        }


        public void StartGame(int numPlayers)
        {
            GameOver = false;
            GameRounds = 0;
            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++) 
            {
                Player p = new Player($"Player{i+1}");
                players.Add(p);
            }
        }


        public void FillDeck()
        {
            int deckSize = (int)Math.Ceiling(players.Count / 2.0); 
            deck = new List<Card>();


            for (int i = 0; i < deckSize; i++) 
            {
                foreach (CardSuit cSuit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardValue cValue in Enum.GetValues(typeof(CardValue)))
                    {
                        deck.Add(new Card(cValue, cSuit));
                    }
                }
            }

            foreach (Player p in players)
            {
                p.Score = 0;

                for (int i = 0; i < 26; i++) 
                { 
                    int index = _rand.Next(0, deck.Count - 1);
                    Card c = deck[index];
                    deck.RemoveAt(index);
                    p.CardDeck.Enqueue(c);
                    //p.CardDeck.Add(c);
                }
            }
        }

        public Card SelectCard(Player player)
        {
            //Card c = player.CardDeck[0];
            //player.CardDeck.RemoveAt(0);
            return player.CardDeck.Dequeue();
        }

        public void PlayRound()
        {
            GameRounds++;
            CardValue highestValue = CardValue.Ace;
            foreach (Player p in players)
            {
                p.CardDrawn = SelectCard(p);
                if (p.CardDrawn.Value > highestValue)
                {
                    highestValue = p.CardDrawn.Value;
                }
            }

            int numPlayersWithMaxValue = 0;

            foreach (Player p in players)
            {
                if (p.CardDrawn.Value == highestValue)
                {
                    numPlayersWithMaxValue++;
                }
            }

            if (numPlayersWithMaxValue > 1) { 
                foreach (Player p in players)
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
                players.Find(p => p.CardDrawn.Value == highestValue)!.Score += 2;
            }

            if (GameRounds == 26)           
            {
                GameOver = true;
                int highScore = 0;
                int numWinners = 1;
                Player winner = new Player();
                foreach (Player p in players)
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

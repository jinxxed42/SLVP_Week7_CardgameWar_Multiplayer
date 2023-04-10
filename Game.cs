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
        //private int deckIndex;
        public List<Player> players;

        // Let's remove Result and integrate the properties in Game.cs!
        // Add player class? Player can then hold the cards and score for itself?

        public Card Player1Card { get; private set; }
        public Card Player2Card { get; private set; }
        public string RoundWinner { get; private set; }
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool GameOver { get; private set; }

        public string GameWinner { get; private set; }


        static Random rand = new Random();

        public Game()
        {

            System.Diagnostics.Debug.WriteLine("1 spiller: " + 52 * (int)Math.Ceiling(1 / 2.0)); //  52
            System.Diagnostics.Debug.WriteLine("2 spiller: " + 52 * (int)Math.Ceiling(2 / 2.0)); //  52
            System.Diagnostics.Debug.WriteLine("3 spiller: " + 52 * (int)Math.Ceiling(3 / 2.0)); // 104
            System.Diagnostics.Debug.WriteLine("4 spiller: " + 52 * (int)Math.Ceiling(4 / 2.0)); // 104
            System.Diagnostics.Debug.WriteLine("5 spiller: " + 52 * (int)Math.Ceiling(5 / 2.0)); // 156
            System.Diagnostics.Debug.WriteLine("6 spiller: " + 52 * (int)Math.Ceiling(6 / 2.0)); // 156

            #region
            //This is a region
            #endregion
        }

        public Game(int numPlayers)
        {
            
        }

        public void StartGame(int numPlayers)
        {
            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++) 
            {
                Player p = new Player($"Player{i+1}");
                players.Add(p);
            }
        }


        public void FillDeck()
        {
            int deckSize = (int)Math.Ceiling(players.Count / 2.0); // Skal rundes op! VIRKER!! Så skal kortene bare fordeles, eller køres 26 runder.
            deck = new List<Card>();
            //deck = new Card[52];
            //deckIndex = 0;

            foreach (Player p in players)
            {
                p.Score = 0;
            }

            Player1Score = 0;
            Player2Score = 0;


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
                for (int i = 0; i < 26; i++) 
                { 
                    int index = rand.Next(0, deck.Count - 1);
                    Card c = deck[index];
                    deck.RemoveAt(index);               
                    p.CardDeck.Add(c);
                }
            }
            /**
            foreach (CardSuit cSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cValue in Enum.GetValues(typeof(CardValue)))
                {
                    deck[deckIndex] = new Card(cValue, cSuit);
                    deckIndex++;
                }
            }
            **/
        }

        public Card SelectCard(Player player)
        {
            //foreach (Player p in players)
            //{
                Card c = player.CardDeck[0];
            player.CardDeck.RemoveAt(0);
            //}

            //int index = rand.Next(0, deck.Count - 1);
            //Card c = deck[index];
            //deck.RemoveAt(index);
            return c;
        }

        public void PlayRound()
        {
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
                players.Find(p => p.CardDrawn.Value == highestValue).Score += 2;
            }

            if (players[0].CardDeck.Count == 0)           
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
                    MessageBox.Show("The game is over and the winner is " + winner.Name);
                }
                else
                {
                    MessageBox.Show("The game is over and it was a draw!");
                }

            }
        }

    }
}

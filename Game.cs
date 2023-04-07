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
        private Card[] deck;
        private int deckIndex;
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


            Player Player1 = new Player();
            Player Player2 = new Player();
            players = new List<Player>();
            players.Add(Player1);
            players.Add(Player2);
            #region
            //This is a region
            #endregion
        }

        public void FillDeck()
        {
            int deckSize = 52 * (int)Math.Ceiling(players.Count / 2.0); // Skal rundes op! VIRKER!! Så skal kortene bare fordeles, eller køres 26 runder.

            deck = new Card[52];
            deckIndex = 0;

            foreach (Player p in players)
            {
                p.Score = 0;
            }

            Player1Score = 0;
            Player2Score = 0;



            foreach (CardSuit cSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cValue in Enum.GetValues(typeof(CardValue)))
                {
                    deck[deckIndex] = new Card(cValue, cSuit);
                    deckIndex++;
                }
            }
        }

        /**
        public void ShowDeck()
        {
            foreach (Card c in deck)
            {
                System.Diagnostics.Debug.WriteLine("Card is: " + c.Value + " of " + c.Suit);
            }
            
        }
        **/

        /**
        public void RunDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Card c = SelectCard();
                System.Diagnostics.Debug.WriteLine("Card number " + (i+1) + ": " + c.Value + " of " + c.Suit + " | Cards left: " + deck.Length);
            }
            
        }
        **/

        public Card SelectCard()
        {
            int index = rand.Next(0, deck.Length - 1);
            Card c = deck[index];
            for (int i = index; i < deck.Length - 1; i++)
            {
                deck[i] = deck[i + 1];
            }
            Array.Resize(ref deck, deck.Length - 1);
            return c;
        }

        public Result PlayRound()
        {
            Player1Card = SelectCard();
            Player2Card = SelectCard();

            string result = "";

            if (Player1Card.Value > Player2Card.Value)
            {
                Player1Score += 2;
                result = "Player1";
                //return new Result("Player1", false);
            }
            else if (Player1Card.Value < Player2Card.Value)
            {
                Player2Score += 2;
                result = "Player2";
                //return new Result("Player2", false);
            }
            else
            {
                Player1Score++;
                Player2Score++;
                result = "Draw";
                //return new Result("Draw", false);
            }

            if (deck.Length != 0)
            {
                return new Result(result, false);
            }
            else
            {
                if (Player1Score > Player2Score)
                {
                    return new Result(result, true, "Player1");
                }
                else if (Player1Score < Player2Score)
                {
                    return new Result(result, true, "Player2");
                }
                else
                {
                    return new Result(result, true, "Draw");
                }
            }
        }

    }
}

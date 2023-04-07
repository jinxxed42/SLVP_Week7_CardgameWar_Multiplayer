using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    internal class Card
    {
        //public int Value { get; set; }
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }

        /**
        public Card(int value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
        **/

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }
    }

    internal enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    internal enum CardValue
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    /**
    enum CardName
    {
        Ace,
        Jack,
        Queen,
        King
    }
    **/
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    internal class Player
    {
        public int Score { get; set; }

        //public List<Card> CardDeck { get; private set; }
        
        public Queue<Card> CardDeck { get; private set; }

        public Card CardDrawn { get; set; }

        public string Name { get; set; }

        public Player()
        {
            
        }

        public Player(string name)
        {
            //CardDeck = new List<Card>();
            CardDeck = new Queue<Card>();
            Name = name;
        }
    }
}

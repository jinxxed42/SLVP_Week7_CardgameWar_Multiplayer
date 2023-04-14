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

        public Queue<Card> CardDeck { get; private set; } = new Queue<Card>(); // The private part still allows for enqueueing elsewhere.

        public Card CardDrawn { get; set; } = null!; // Will never be null when accessed due to the design of the game code.

        public string Name { get; set; } = string.Empty;
        
        // Only used for creating an "empty" Player object that is immediately set to equal an existing Player.
        public Player()
        {
            
        }

        public Player(string name)
        {
            Name = name;
        }
    }
}

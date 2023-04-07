using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    // MÅSKE REDUCER STØRRELSE PÅ STRINGS OG KØR STRUCT?!
    internal class Result
    {
        public string Winner { get; private init; }

        public bool GameOver { get; private init; }

        public string GameWinner { get; private init; }

        /**
        public Card Player1Card { get; private init; }

        public Card Player2Card { get; private init; }
        **/

        // BØR INDEHOLDE KORTENE OGSÅ!!!!

        public Result(string winner, bool gameOver)
        {
            Winner = winner;
            GameOver = gameOver;
        }

        public Result(string winner, bool gameOver, string gameWinner)
        {
            Winner = winner;
            GameOver = gameOver;
            GameWinner = gameWinner;
        }

        /**
        public Result(string winner, bool gameOver, Card player1Card, Card player2Card)
        {
            Winner = winner;
            GameOver = gameOver;
            Player1Card = player1Card;
            Player2Card = player2Card;
        }

        public Result(string winner, bool gameOver, , Card player1Card, Card player2Card)
        {
            Winner = winner;
            GameOver = gameOver;
            GameWinner = gameWinner;
            Player1Card = player1Card;
            Player2Card = player2Card;
        }
        **/

    }
}

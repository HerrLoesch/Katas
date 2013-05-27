
using System;

namespace Tennis
{
    public class Scorecard
    {

        public Scorecard()
        {
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }
        /// <summary>
        /// Gibt den aktuellen Spielstand zurück
        /// </summary>
        /// <returns>Zahl:Zahl</returns>
        public string GetCurrentGamePoints()
        {
            if (PlayerOne.HasAdvantage)
                return "Player1 has advantage";
            else if (PlayerTwo.HasAdvantage)
                return "Player2 has advantage";

            if (PlayerOne.HasWon)
                return "Player1 has won";
            else if (PlayerTwo.HasWon)
                return "Player2 has won";

            return PlayerOne.Points+":"+PlayerTwo.Points;
        }

        public Player PlayerOne
        {
            get; private set;
        }

        public Player PlayerTwo { get; private set; }
    }
}

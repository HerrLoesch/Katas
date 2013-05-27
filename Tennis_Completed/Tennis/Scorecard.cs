using System.Collections.Generic;

namespace Tennis
{
    public class Scorecard
    {
        private readonly Dictionary<int, string> pointMapping = new Dictionary<int, string>
                                                                    {
                                                                        {0, "Love"},
                                                                        {15, "Fifteen"},
                                                                        {30, "Thirty"},
                                                                        {40, "Fourty"}
                                                                    };

        private readonly Player playerA;
        private readonly Player playerB;

        public Scorecard(Player playerA, Player playerB)
        {
            this.playerA = playerA;
            this.playerB = playerB;
        }

        public string GetCurrentGamePoints()
        {
            if(playerA.HasWon)
            {
                return "Player A wins";
            }

            if(playerB.HasWon)
            {
                return "Player B wins";
            }

            if(playerA.Points == 40 && playerB.Points == 40
                && !(playerA.HasAdvantage || playerB.HasAdvantage))
            {
                return "Deuce";
            }

            if(playerA.HasAdvantage)
            {
                return "Advantage Player A";
            }

            if(playerB.HasAdvantage)
            {
                return "Advantage Player B";
            }

            return pointMapping[playerA.Points] + " - " + pointMapping[playerB.Points];
        }

        public void AwardPointToPlayer(Player player)
        {
            switch (player.Points)
            {
                case 0:
                    player.Points = 15;
                    break;
                case 15:
                    player.Points = 30;
                    break;
                case 30:
                    player.Points = 40;
                    break;
                case 40:
                    if (!playerA.HasAdvantage && !playerB.HasAdvantage)
                    {
                        if (playerA.Points == 40 && playerB.Points == 40)
                        {
                            player.HasAdvantage = true;
                        }
                        else
                        {
                            player.HasWon = true;
                        }
                    }
                    else
                    {
                        if(player.HasAdvantage)
                        {
                            player.HasWon = true;
                            return;
                        }

                        playerA.HasAdvantage = false;
                        playerB.HasAdvantage = false;
                    }
                    break;
            }
        }
    }
}

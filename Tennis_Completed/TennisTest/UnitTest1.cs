using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis;

namespace TennisTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShallGamePointBeLoveFifteen()
        {
            var playerA = new Player();
            var playerB = new Player();

            var scorecard = new Scorecard(playerA, playerB);
            scorecard.AwardPointToPlayer(playerB);

            Assert.AreEqual("Love - Fifteen", scorecard.GetCurrentGamePoints());
        }

        [TestMethod]
        public void BothPlayersAreAtDeuceWhenTheyHaveFourtyPoints()
        {
            var playerA = new Player();
            var playerB = new Player();

            var scorecard = new Scorecard(playerA, playerB);

            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);

            Assert.AreEqual("Deuce", scorecard.GetCurrentGamePoints());
        }

        [TestMethod]
        public void ShallPlayerWinTheGameWhenSheWinsTheBallAtFourtyAndOtherPlayerHasLessThanFourty()
        {
            var playerA = new Player();
            var playerB = new Player();

            var scorecard = new Scorecard(playerA, playerB);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerB);

            Assert.AreEqual("Player B wins", scorecard.GetCurrentGamePoints());
        }

        [TestMethod]
        public void ShallPlayerHaveAdvantageWhenSheWinsTheBallAtFourtyAndOtherPlayerHasFourty()
        {
            var playerA = new Player();
            var playerB = new Player();

            var scorecard = new Scorecard(playerA, playerB);

            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerB);

            Assert.AreEqual("Advantage Player B", scorecard.GetCurrentGamePoints());
        }

        [TestMethod]
        public void ShallPlayersReturnToDeuceIfOnePlayerLoosesAdvantage()
        {
            var playerA = new Player();
            var playerB = new Player();

            var scorecard = new Scorecard(playerA, playerB);

            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerB);
            scorecard.AwardPointToPlayer(playerA);

            Assert.AreEqual("Deuce", scorecard.GetCurrentGamePoints());
        }
    }
}

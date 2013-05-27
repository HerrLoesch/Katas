using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis;

namespace Tenis.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ScorecardTests
    {
        [TestMethod]
        public void PlayerHasAdvantage()
        {
            var scorecard = new Scorecard();
            scorecard.PlayerOne.HasAdvantage = true;

            var hasAdvantage = scorecard.GetCurrentGamePoints();

            Assert.AreEqual("Player1 has advantage", hasAdvantage);
        }

        [TestMethod]
        public void Player1HasWon()
        {
            var scorecard = new Scorecard();
            scorecard.PlayerOne.HasWon = true;

            var hasAdvantage = scorecard.GetCurrentGamePoints();

            Assert.AreEqual("Player1 has won", hasAdvantage);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var scorecard = new Scorecard();

            scorecard.PlayerOne.Points = 15;
            scorecard.PlayerTwo.Points = 30;

            string points = scorecard.GetCurrentGamePoints();
            
            Assert.AreEqual("15:30", points);
        }
    }
}
    
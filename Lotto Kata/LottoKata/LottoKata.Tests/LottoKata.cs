// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LottoKata.cs" company="">
//   
// </copyright>
// <summary>
//   The lotto kata.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LottoKata.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// The lotto kata.
    /// </summary>
    [TestFixture]
    public class LottoKata
    {
        #region Public Methods and Operators

        [Test]
        [TestCaseSource(typeof(LottoTestDataFactory), "GetTestCases")]
        public WinningClasses WinningClassesTests(Ticket drawn, Ticket played)
        {
            var sut = new WinningClassCalculator();

            return sut.CalculateWinningClass(drawn, played);
        }

        #endregion
    }

    /// <summary>
    /// The lotto test data factory.
    /// </summary>
    public class LottoTestDataFactory
    {
        #region Public Methods and Operators

        public static IEnumerable GetTestCases()
        {
            var drawnTicket = new Ticket
                {
                   Numbers = new List<int> { 44, 45, 46, 47, 48, 49 }, Additional = 17, Super = 9 
                };

            var classEightTicket = new Ticket { Numbers = new List<int> { 4, 5, 6, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classEightTicket).Returns(WinningClasses.VIII);

            var classSevenTicket = new Ticket { Numbers = new List<int> { 17, 5, 6, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classSevenTicket).Returns(WinningClasses.VII);

            var classSixTicket = new Ticket { Numbers = new List<int> { 4, 5, 46, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classSixTicket).Returns(WinningClasses.VI);

            var classFiveTicket = new Ticket { Numbers = new List<int> { 17, 5, 46, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classFiveTicket).Returns(WinningClasses.V);

            var classFourTicket = new Ticket { Numbers = new List<int> { 4, 45, 46, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classFourTicket).Returns(WinningClasses.IV);

            var classThreeTicket = new Ticket { Numbers = new List<int> { 17, 45, 46, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classThreeTicket).Returns(WinningClasses.III);

            var classTwoTicket = new Ticket { Numbers = new List<int> { 44, 45, 46, 47, 48, 49 }, Super = 0 };
            yield return new TestCaseData(drawnTicket, classTwoTicket).Returns(WinningClasses.II);

            var classOneTicket = new Ticket { Numbers = new List<int> { 44, 45, 46, 47, 48, 49 }, Super = 9 };
            yield return new TestCaseData(drawnTicket, classOneTicket).Returns(WinningClasses.I);
        }

        #endregion
    }
}
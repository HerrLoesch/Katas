using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzMSTest
{
    [TestClass]
    public class FizzBuzzConverterTests
    {
        private CompositeNumberConverter sut;

        [TestInitialize]
        public void Initialize()
        {
            this.sut = new CompositeNumberConverter(new NumberConverter(), new FizzConverter(), new BuzzConverter());
        }

        [TestMethod]
        public void Number_1_ResultsIn_1()
        {
            var result = this.sut.Convert(1);

            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void Number_2_ResultsIn_2()
        {
            var result = this.sut.Convert(2);

            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Number_3_ResultsIn_Fizz()
        {
            var result = this.sut.Convert(3);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void Number_4_ResultsIn_4()
        {
            var result = this.sut.Convert(4);

            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void Number_5_ResultsIn_Buzz()
        {
            var result = this.sut.Convert(5);

            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void Number_6_ResultsIn_Fizz()
        {
            var result = this.sut.Convert(6);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void Number_10_ResultsIn_Buzz()
        {
            var result = this.sut.Convert(10);

            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void Number_15_ResultsIn_FizzBuzz()
        {
            var result = this.sut.Convert(15);

            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod]
        public void Number_30_ResultsIn_FizzBuzz()
        {
            var result = this.sut.Convert(30);

            Assert.AreEqual("FizzBuzz", result);
        }
    }
}

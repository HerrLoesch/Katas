using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Any_live_cell_with_fewer_than_two_live_neighbours_dies()
        {
            var sut = new Game();

            var source = new bool[3,3];
            source[1, 1] = true;

            source = sut.Play(source);

            Assert.AreEqual(false, source[1,1]);
        }

        [TestMethod]
        public void Any_live_cell_with_two_live_neighbours_lives()
        {
            var sut = new Game();

            var source = new bool[3,3];
            source[1, 1] = true;
            source[0, 2] = true;
            source[2, 1] = true;

            source = sut.Play(source);

            Assert.AreEqual(true, source[1,1]);
        }

        [TestMethod]
        public void Any_live_cell_with_three_live_neighbours_lives()
        {
            var sut = new Game();

            var source = new bool[3, 3];
            source[1, 1] = true;
            source[0, 2] = true;
            source[2, 1] = true;
            source[2, 2] = true;

            source = sut.Play(source);

            Assert.AreEqual(true, source[1, 1]);
        }

        [TestMethod]
        public void Any_live_cell_with_more_than_three_live_neighbours_dies()
        {
            var sut = new Game();

            var source = new bool[3, 3];
            source[1, 1] = true;
            source[0, 2] = true;
            source[2, 1] = true;
            source[2, 2] = true;
            source[1, 2] = true;

            source = sut.Play(source);

            Assert.AreEqual(false, source[1, 1]);
        }

        [TestMethod]
        public void Any_dead_cell_with_exactly_three_live_neighbours_becomes_a_live_cell()
        {
            var sut = new Game();

            var source = new bool[3, 3];
            source[1, 1] = false;
            source[0, 2] = true;
            source[2, 1] = true;
            source[2, 2] = true;

            source = sut.Play(source);

            Assert.AreEqual(true, source[1, 1]);
        }

        [TestMethod]
        public void Any_dead_cell_with_exactly_two_live_neighbours_is_still_dead()
        {
            var sut = new Game();

            var source = new bool[3, 3];
            source[1, 1] = false;
            source[0, 2] = true;
            source[2, 1] = true;

            source = sut.Play(source);

            Assert.AreEqual(false, source[1, 1]);
        }
    }
}
    
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConnectFour.Core.Tests
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void LineCanDetectWinnerIfItHasFourInALine()
        {
            var cells = new List<Cell>
                        {
                            new Cell(0, 0) { Chip = new Chip("Foo", new Color(128, 0, 0)) },
                            new Cell(0, 1) { Chip = new Chip("Bar", new Color(128, 0, 0)) },
                            new Cell(0, 2) { Chip = new Chip("Bar", new Color(128, 0, 0)) },
                            new Cell(0, 3) { Chip = new Chip("Bar", new Color(128, 0, 0)) },
                            new Cell(0, 4) { Chip = new Chip("Bar", new Color(128, 0, 0)) },
                            new Cell(0, 5),
                            new Cell(0, 6)
                        };
            var testTarget = new LineDummy(cells);

            var winnerName = testTarget.DetermineIfPlayerHasFourInALine();

            Assert.AreEqual("Bar", winnerName);
        }

        [TestMethod]
        public void LineDetectsNoWinnerWhenNoPlayerHasFourInALine()
        {
            var cells = new List<Cell>
                        {
                            new Cell(0, 0) { Chip = new Chip("Foo", new Color(128, 0, 0)) },
                            new Cell(0, 1) { Chip = new Chip("Bar", new Color(128, 0, 0)) },
                            new Cell(0, 2),
                            new Cell(0, 3),
                            new Cell(0, 4),
                            new Cell(0, 5),
                            new Cell(0, 6)
                        };
            var testTarget = new LineDummy(cells);

            var winnerName = testTarget.DetermineIfPlayerHasFourInALine();

            Assert.AreEqual(null, winnerName);
        }
    }
}
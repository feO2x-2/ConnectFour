using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ConnectFour.Core.Tests
{
    [TestClass]
    public class BoardFactoryTests
    {
        private Board _board;

        [TestInitialize]
        public void TestInitialize()
        {
            _board = new BoardFactory().CreateBoard(7, 6);
        }

        [TestMethod]
        public void DiagonalsContainTheCorrectCells()
        {
            var sampleDiagonal = _board.Diagonals.First(diagonal => diagonal.ColumnIndex == 3 &&
                                                                   diagonal.RowIndex == 0 &&
                                                                   diagonal.Direction == DiagonalDirection.TopRightToBottomLeft);

            Assert.AreEqual(3, sampleDiagonal.Cells[0].X);
            Assert.AreEqual(0, sampleDiagonal.Cells[0].Y);
            Assert.AreEqual(2, sampleDiagonal.Cells[1].X);
            Assert.AreEqual(1, sampleDiagonal.Cells[1].Y);
            Assert.AreEqual(1, sampleDiagonal.Cells[2].X);
            Assert.AreEqual(2, sampleDiagonal.Cells[2].Y);
            Assert.AreEqual(0, sampleDiagonal.Cells[3].X);
            Assert.AreEqual(3, sampleDiagonal.Cells[3].Y);
        }

        [TestMethod]
        public void DiagonalsWithLessThanFourCellsAreNotIncluded()
        {
            Assert.IsTrue(_board.Diagonals.All(diagonal => diagonal.Cells.Count >= 4));
        }

        [TestMethod]
        public void ColumnsContainTheCorrectCells()
        {
            var sampleColumn = _board.Columns[1];
            for (var i = 0; i < 6; i++)
            {
                Assert.AreEqual(1, sampleColumn.Cells[i].X);
                Assert.AreEqual(5 - i, sampleColumn.Cells[i].Y);
            }
        }

        [TestMethod]
        public void RowsContainCorrectCells()
        {
            var sampleRow = _board.Rows[4];
            for (var i = 0; i < 7; i++)
            {
                Assert.AreEqual(4, sampleRow.Cells[i].Y);
                Assert.AreEqual(i, sampleRow.Cells[i].X);
            }
        }
    }
}

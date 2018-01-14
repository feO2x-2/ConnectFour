using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConnectFour.Core.Tests
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void ChipCanBeAddedToColumnWhenItIsNotFull()
        {
            // Arrange
            var fixture = new ColumnFixture().WithNumberOfEmptyCells(6);
            var testTarget = fixture.CreateTestTarget();
            var chip = fixture.CreateChip();

            // Act
            testTarget.SetChip(chip);

            // Assert
            Assert.AreEqual(chip, fixture.Cells[0].Chip);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionIsThrownWhenChipIsAddedToFullColumn()
        {
            // Arrange
            var fixture = new ColumnFixture().WithNumberOfCellsWithChip(6);
            var testTarget = fixture.CreateTestTarget();
            var chip = fixture.CreateChip();

            // Act
            testTarget.SetChip(chip);
        }

        [TestMethod]
        public void IsFullMustReturnTrueWhenAllCellsHaveAChipInIt()
        {
            // Arrange
            var fixutre = new ColumnFixture().WithNumberOfCellsWithChip(6);
            var testTarget = fixutre.CreateTestTarget();

            // Assert
            Assert.IsTrue(testTarget.IsFull);
        }

        [TestMethod]
        public void IsFullMustReturnFalseWhenNotAllCellsHaveAChipInIt()
        {
            // Arrange
            var fixture = new ColumnFixture().WithNumberOfCellsWithChip(3)
                                             .WithNumberOfEmptyCells(3);
            var testTarget = fixture.CreateTestTarget();

            // Assert
            Assert.IsFalse(testTarget.IsFull);
        }
    }
}
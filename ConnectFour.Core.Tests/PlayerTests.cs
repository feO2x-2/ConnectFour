using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ConnectFour.Core.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void SetChipRemovesOneChipFromThePlayersCollection()
        {
            var color = new Color(128, 0, 0);
            var chips = new List<Chip>
                        {
                            new Chip("Foo", color),
                            new Chip("Foo", color)
                        };
            var initialCount = chips.Count;
            var testTarget = new Player("Foo", color, chips);
            var columnDummy = new Mock<IColumn>();

            testTarget.PlaceChipInColumn(columnDummy.Object);

            Assert.AreEqual(initialCount - 1, testTarget.Chips.Count);
        }

        [TestMethod]
        public void PlaceChipInColumnCallsPlaceChipOnTheParameterObject()
        {
            var color = new Color(128, 0, 0);
            var chips = new List<Chip>
                        {
                            new Chip("Foo", color),
                            new Chip("Foo", color)
                        };
            var testTarget = new Player("Foo", color, chips);
            var columnMock = new Mock<IColumn>();

            testTarget.PlaceChipInColumn(columnMock.Object);

            columnMock.Verify(m => m.SetChip(It.IsAny<Chip>()));
        }
    }
}

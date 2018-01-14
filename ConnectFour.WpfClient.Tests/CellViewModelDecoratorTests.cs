using ConnectFour.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class CellViewModelDecoratorTests
    {
        [TestMethod]
        public void PropertyChangedIsRaisedWhenChipIsSet()
        {
            var testTarget = new CellViewModelDecorator(new CellMock());
            string propertyName = null;
            testTarget.PropertyChanged += (s, e) => propertyName = e.PropertyName;
            var chip = new Chip("Foo", new Color(128, 0, 0));

            testTarget.Chip = chip;

            Assert.AreEqual("Chip", propertyName);
        }

        [TestMethod]
        public void CellClickedIsRaisedWhenCommandIsExecuted()
        {
            var testTarget = new CellViewModelDecorator(new CellMock());
            ICell eventArgument = null;
            testTarget.CellClicked += c => eventArgument = c;

            testTarget.ClickCellCommand.Execute(null);

            Assert.AreEqual(testTarget, eventArgument);
        }

        [TestMethod]
        public void XAndYCoordianteAreReturnedFromEncapuslatedCell()
        {
            var encapsulatedCell = new CellMock(1, 4);
            var testTarget = new CellViewModelDecorator(encapsulatedCell);

            Assert.AreEqual(encapsulatedCell.X, testTarget.X);
            Assert.AreEqual(encapsulatedCell.Y, testTarget.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class HasTurnToBrushConverterTests
    {
        private HasTurnToBrushConverter _testTarget;

        [TestInitialize]
        public void TestInitialize()
        {
            _testTarget = new HasTurnToBrushConverter();
        }

        [TestMethod]
        public void ConverterReturnsTransparentBrushOnFalse()
        {
            var brush = (SolidColorBrush)_testTarget.Convert(false, null, null, null);

            Assert.AreEqual(Colors.Transparent, brush.Color);
        }

        [TestMethod]
        public void ConverterReturnsTransparentBrushOnTrue()
        {
            var brush = (SolidColorBrush)_testTarget.Convert(true, null, null, null);

            Assert.AreEqual(Colors.Silver, brush.Color);
        }
    }
}

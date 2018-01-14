using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class ColorConverterTests
    {
        [TestMethod]
        public void ColorConverterReturnsBrushWithCorrespondingRgbValues()
        {
            var color = new Core.Color(255, 128, 0);
            var testTarget = new ColorConverter();

            var resultingBrush = (SolidColorBrush) testTarget.Convert(color, null, null, null);

            var expectedColor = Color.FromRgb(color.Red, color.Green, color.Blue);
            Assert.AreEqual(expectedColor, resultingBrush.Color);
        }
    }
}

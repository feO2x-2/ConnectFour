using ConnectFour.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class PlayerViewModelTests
    {
        [TestMethod]
        public void PropertyChangedIsRaisedWhenHasTurnIsChanged()
        {
            var testTarget = new PlayerViewModel(new Player("Foo", new Color(0, 0, 0), new List<Chip>()));
            var callCount = 0;
            testTarget.PropertyChanged += (sender, args) => callCount++;

            testTarget.HasTurn = !testTarget.HasTurn;

            Assert.AreEqual(1, callCount);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class FunctionalCommandTests
    {
        [TestMethod]
        public void FunctionalCommandReturnsTrueWhenNoCanExecuteDelegateIsSpecified()
        {
            var testTarget = new FunctionalCommand(() => { });

            var actual = testTarget.CanExecute(null);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void FunctionalCommandCallsExecuteDelegateOnExecute()
        {
            var numberOfCalls = 0;
            var testTarget = new FunctionalCommand(() => numberOfCalls++);

            testTarget.Execute(null);

            Assert.AreEqual(1, numberOfCalls);
        }

        [TestMethod]
        public void FunctionalCommandReturnsValueOfCanExecuteDelegateCorrectly()
        {
            var returnValue = false;
            // ReSharper disable once AccessToModifiedClosure
            // This is actually what I want here
            var testTarget = new FunctionalCommand(() => { }, () => returnValue);

            var actual = testTarget.CanExecute(null);
            Assert.AreEqual(false, actual);

            returnValue = true;
            actual = testTarget.CanExecute(null);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CanExecuteChangedIsRaisedWhenRaisePropertyChangedIsCalled()
        {
            var testTarget = new FunctionalCommand(() => { });
            var numberOfCalls = 0;
            testTarget.CanExecuteChanged += (s, e) => numberOfCalls++;

            testTarget.RaiseCanExecuteChanged();

            Assert.AreEqual(1, numberOfCalls);
        }
    }
}
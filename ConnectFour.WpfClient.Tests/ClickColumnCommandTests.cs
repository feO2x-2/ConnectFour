using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class ClickColumnCommandTests
    {
        private MainWindowViewModelMock _mainWindowViewModelMock;
        private ClickColumnCommand _testTarget;
        private ColumnMock _columnMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mainWindowViewModelMock = new MainWindowViewModelMock();
            _columnMock = new ColumnMock();
            _testTarget = new ClickColumnCommand(_columnMock, _mainWindowViewModelMock);
        }

        [TestMethod]
        public void CommandRaisesCanExecuteChangedWhenWinnerIsSetInMainWindowViewModel()
        {
            var numberOfCanExecuteChangedCalls = 0;
            _testTarget.CanExecuteChanged += (sender, args) => numberOfCanExecuteChangedCalls++;

            _mainWindowViewModelMock.SetWinnerName("Foo");

            Assert.AreEqual(1, numberOfCanExecuteChangedCalls);
        }

        [TestMethod]
        public void CanExecuteReturnsTrueWhenWinnerNameIsNotSetAndColumnIsNotFull()
        {
            var canExecute = _testTarget.CanExecute(null);

            Assert.IsTrue(canExecute);
        }

        [TestMethod]
        public void CanExecuteReturnsFalseWhenColumnIsFull()
        {
            _columnMock.IsFull = true;
            var canExecute = _testTarget.CanExecute(null);

            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void CanExecuteReturnsFalseWhenWinnerIsSet()
        {
            _mainWindowViewModelMock.SetWinnerName("Foo");

            var canExecute = _testTarget.CanExecute(null);

            Assert.IsFalse(canExecute);
        }

        [TestMethod]
        public void ExecuteCallsPlayTurnOnMainWindowViewModel()
        {
            _testTarget.Execute(null);

            Assert.IsTrue(_mainWindowViewModelMock.WasPlayTurnCalledExactlyOnce);
        }

        [TestMethod]
        public void ExecuteRaisesCanExecuteChangedWhenColumnBecomesFullAfterTurn()
        {
            var numberOfCanExecuteChangedCalls = 0;
            _testTarget.CanExecuteChanged += (sender, args) => numberOfCanExecuteChangedCalls++;
            _columnMock.IsFull = true;

            _testTarget.Execute(null);

            Assert.AreEqual(1, numberOfCanExecuteChangedCalls);
        }
    }
}

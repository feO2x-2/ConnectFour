using ConnectFour.WpfClient.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConnectFour.WpfClient.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private PlayerMock _playerAMock;
        private PlayerMock _playerBMock;
        private BoardMock _boardMock;
        private IMainWindowViewModel _testTarget;
        private List<PlayerViewModelMock> _playerViewModelMocks;
        private int _showWinnerDialogCount;

        [TestInitialize]
        public void TestInitialize()
        {
            _playerAMock = new PlayerMock();
            _playerBMock = new PlayerMock();
            _boardMock = new BoardMock();

            _playerViewModelMocks = new List<PlayerViewModelMock>
                                     {
                                         new PlayerViewModelMock(_playerAMock) { HasTurn = true },
                                         new PlayerViewModelMock(_playerBMock)
                                     };

            _testTarget = new MainWindowViewModel(_playerViewModelMocks, new BoardViewModelSampleData(), _boardMock, winner => _showWinnerDialogCount++);
        }

        [TestMethod]
        public void PlayTurnForwardsCallToPlayerObject()
        {
            _testTarget.PlayTurn(new ColumnMock());

            Assert.IsTrue(_playerAMock.WasPlaceChipInColumnCalledExactlyOnce &&
                          _playerBMock.NumberOfPlaceChipInColumnCalls == 0);
        }

        [TestMethod]
        public void PlayTurnCallsPropertyChangedWhenWinnerIsDetermined()
        {
            _boardMock.WinnerName = "Foo";
            var numberOfPropertyChangedCalls = 0;
            _testTarget.PropertyChanged += (sender, args) => numberOfPropertyChangedCalls++;

            _testTarget.PlayTurn(new ColumnMock());

            Assert.AreEqual(1, numberOfPropertyChangedCalls);
            Assert.AreEqual("Foo wins!", _testTarget.GameText);
        }

        [TestMethod]
        public void PlayTurnDoesNotChangedPlayersWhenWinnerIsDetermined()
        {
            _boardMock.WinnerName = "Foo";

            _testTarget.PlayTurn(new ColumnMock());

            Assert.IsTrue(_playerViewModelMocks[0].HasTurn &&
                          _playerViewModelMocks[1].HasTurn == false);
        }

        [TestMethod]
        public void PlayTurnChangesTurnWhenNoWinnerIsDetermined()
        {
            _testTarget.PlayTurn(new ColumnMock());

            Assert.IsTrue(_playerViewModelMocks[0].HasTurn == false &&
                          _playerViewModelMocks[1].HasTurn);
        }
    }
}
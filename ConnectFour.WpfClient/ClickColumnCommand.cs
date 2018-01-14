using ConnectFour.Core;
using System;
using System.ComponentModel;

namespace ConnectFour.WpfClient
{
    public class ClickColumnCommand : IClickColumnCommand
    {
        private readonly IColumn _column;
        private readonly IMainWindowViewModel _mainWindowViewModel;

        public ClickColumnCommand(IColumn column, IMainWindowViewModel mainWindowViewModel)
        {
            if (column == null) throw new ArgumentNullException("column");
            if (mainWindowViewModel == null) throw new ArgumentNullException("mainWindowViewModel");

            _column = column;
            _mainWindowViewModel = mainWindowViewModel;
            _mainWindowViewModel.PropertyChanged += MainWindowViewModelOnPropertyChanged;
        }

        private void MainWindowViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "GameText")
                OnCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return _column.IsFull == false && string.IsNullOrEmpty(_mainWindowViewModel.GameText);
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.PlayTurn(_column);
            if (_column.IsFull)
                OnCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;

        private void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public int ColumnIndex
        {
            get { return _column.Index; }
        }
    }
}
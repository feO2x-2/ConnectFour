using System;

namespace ConnectFour.WpfClient.SampleData
{
    public class ClickColumnCommandDummy : IClickColumnCommand
    {
        private readonly int _columnIndex;
        private readonly bool _canExecute;

        public ClickColumnCommandDummy(int columnIndex, bool canExecute)
        {
            _columnIndex = columnIndex;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            
        }

        public event EventHandler CanExecuteChanged;

        public int ColumnIndex
        {
            get { return _columnIndex; }
        }
    }
}
using System;
using System.Collections.Generic;
using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class CellViewModelDecoratorFactory : ICellFactory
    {
        private readonly IList<CellViewModelDecorator> _createdCellViewModelDecorators;
        public CellViewModelDecoratorFactory(IList<CellViewModelDecorator> createdCellViewModelDecorators)
        {
            if (createdCellViewModelDecorators == null) throw new ArgumentNullException("createdCellViewModelDecorators");

            _createdCellViewModelDecorators = createdCellViewModelDecorators;
        }

        public ICell Create(int columnIndex, int rowIndex)
        {
            var newCell = new CellViewModelDecorator(new Cell(columnIndex, rowIndex));
            _createdCellViewModelDecorators.Add(newCell);
            return newCell;
        }
    }
}

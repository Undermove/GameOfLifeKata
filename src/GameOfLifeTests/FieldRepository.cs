using System;

namespace GameOfLifeTests
{
    public class FieldRepository : IFieldRepository
    {
        private readonly Cell[,] _field;

        public FieldRepository(char[,] rawField)
        {
            int rowsCount = rawField.GetLength(0);
            int columnsCount = rawField.GetLength(1);

            _field = new Cell[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    if (rawField[i, j] != '*' && rawField[i, j] != '.')
                    {
                        throw new ArgumentException(
                            string.Format("Invalid symbol detected in \nrow:{0} \ncolumn:{1}", i, j)
                        );
                    }

                    bool isAlive = rawField[i, j] == '*';
                    _field[i, j] = new Cell(this, isAlive, new Point(i, j));
                }
            }
        }

        public int GetAliveCellsCountForPosition(Point position)
        {
            int aliveCellsCount = 8;
            int rightShift = position.J + 1;
            int downShift = position.I + 1;
            int upperShift = position.I - 1 > 0 ? position.I - 1 : _field.GetLength(0) - 1;
            int leftShift = position.J - 1 > 0 ? position.J - 1 : _field.GetLength(1) - 1;

            if (!_field[position.I, rightShift].IsAlive)
            {
                aliveCellsCount--;
            }

            if (!_field[downShift, position.J].IsAlive)
            {
                aliveCellsCount--;
            }

            if (!_field[downShift, rightShift].IsAlive)
            {
                aliveCellsCount--;
            }

            if (!_field[upperShift, position.J].IsAlive)
            {
                aliveCellsCount--;
            }

            if (!_field[position.I, leftShift].IsAlive)
            {
                aliveCellsCount--;
            }

            return aliveCellsCount;
        }

        public int GetAliveCellsCount()
        {
            int aliveCellsCount = 0;

            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    if (_field[i, j].IsAlive)
                    {
                        aliveCellsCount++;
                    }
                }
            }

            return aliveCellsCount;
        }
    }
}
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
                    if (rawField[i, j] != '*' ||
                        rawField[i, j] != '.')
                    {
                        throw new ArgumentException(
                            string.Format("Invalid symbol detected in \nrow:{0} \ncolumn:{1}", i, j)
                            );
                    }
                }
            }
        }
        
        public int GetAliveCellsCount(Point position)
        {
            return 9;
        }
    }
}
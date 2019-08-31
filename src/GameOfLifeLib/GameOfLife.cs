using System;
using System.Text;

namespace GameOfLifeLib
{
    public class GameOfLife
    {
        public string GetNextGeneration(string currentGeneration)
        {
            var dimensionsAndField = currentGeneration.Split('\n');
            var dimensions = dimensionsAndField[0];
            var rowsAndColumns = dimensions.Split(',');
            var rows = Convert.ToInt32(rowsAndColumns[0]);
            var columns = Convert.ToInt32(rowsAndColumns[1]);
            char[,] field = StringToFieldConverter.ConvertToField(dimensions, dimensionsAndField[1]);

            var nextGenerationBuilder = new StringBuilder();

            if (columns == rows && rows == 1)
            {
                nextGenerationBuilder.Append('.');
                return dimensions + '\n' + nextGenerationBuilder;
            }

            for (var i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var cell = field[i, j];

                    var lastCell = j - 1 >= 0 ? field[i, j - 1] : field[i, columns - 1];
                    var nextCell = j + 1 > columns - 1 ? field[i, 0] : field[i, j + 1];
                    var upperCell = i + 1 > rows - 1 ? field[0, j] : field[i + 1, j];
                    
                    
                    var aliveNeighbours = 0;

                    aliveNeighbours = lastCell == '*' ? aliveNeighbours + 1 : aliveNeighbours;
                    aliveNeighbours = nextCell == '*' ? aliveNeighbours + 1 : aliveNeighbours;
                    aliveNeighbours = upperCell == '*' ? aliveNeighbours + 1 : aliveNeighbours;

                    if (aliveNeighbours == 2 && cell == '.')
                    {
                        nextGenerationBuilder.Append('.');
                        continue;
                    }

                    if (aliveNeighbours == 3 || aliveNeighbours == 2)
                    {
                        nextGenerationBuilder.Append('*');
                    }
                    else
                    {
                        nextGenerationBuilder.Append('.');
                    }
                }
            }

            return dimensions + '\n' + nextGenerationBuilder;
        }
    }
}
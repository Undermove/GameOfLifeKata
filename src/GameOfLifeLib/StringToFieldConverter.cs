using System;

namespace GameOfLifeLib
{
    public static class StringToFieldConverter
    {
        public static char[,] ConvertToField(string dimensions, string s)
        {
            var rowsAndColumns = dimensions.Split(',');
            var rows = Convert.ToInt32(rowsAndColumns[0]);
            var columns = Convert.ToInt32(rowsAndColumns[1]);
            
            var field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = s[i*columns + j];
                }
            }

            return field;
        }
    }
}
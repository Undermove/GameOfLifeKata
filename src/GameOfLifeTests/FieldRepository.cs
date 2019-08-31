namespace GameOfLifeTests
{
    public class FieldRepository : IFieldRepository
    {
        private readonly char[,] _field;

        public FieldRepository(char[,] field)
        {
            _field = field;
        }
        
        public int GetAliveCellsCount(Point position)
        {
            return 9;
        }
    }
}
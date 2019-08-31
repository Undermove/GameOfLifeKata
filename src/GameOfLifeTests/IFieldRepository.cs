namespace GameOfLifeTests
{
    public interface IFieldRepository
    {
        int GetAliveCellsCount(Point position);
    }
}
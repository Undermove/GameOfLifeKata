namespace GameOfLifeTests
{
    public interface IFieldRepository
    {
        int GetAliveCellsCountForPosition(Point position);
    }
}
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class FieldRepositoryGetAliveCellsCountShould
    {
        [Test]
        public void ReturnNineAliveNeighboursCount_WhenPointIsInLeftUpperCorner_AndAllCellsAlive()
        {
            char[,] _field =
            {
                {'*', '*', '*'},
                {'*', '*', '*'},
                {'*', '*', '*'}
            };
            var _repository = new FieldRepository(_field);

            var aliveCellsCount = _repository.GetAliveCellsCount(new Point(0, 0));

            Assert.AreEqual(9, aliveCellsCount);
        }
    }
}
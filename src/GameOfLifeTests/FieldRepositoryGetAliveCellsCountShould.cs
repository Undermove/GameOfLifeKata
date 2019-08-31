using NUnit.Framework;

namespace GameOfLifeTests
{
    public class FieldRepositoryGetAliveCellsCountShould
    {
        [Test]
        public void ReturnEightAliveNeighboursCount_WhenPointInLeftUpperCorner_AndAllCellsAlive()
        {
            char[,] _field =
            {
                {'*', '*', '*'},
                {'*', '*', '*'},
                {'*', '*', '*'}
            };
            var _repository = new FieldRepository(_field);

            var aliveCellsCount = _repository.GetAliveCellsCountForPosition(new Point(0, 0));

            Assert.AreEqual(8, aliveCellsCount);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        public void ReturnSevenAliveNeighboursCount_WhenPointInLeftUpperCorner_AndOneDeadCellInNearPosition(
            int deadCellRow, 
            int deadCellColumn)
        {
            char[,] _field =
            {
                {'*', '*', '*'},
                {'*', '*', '*'},
                {'*', '*', '*'}
            };
            _field[deadCellRow, deadCellColumn] = '.'; 
            var _repository = new FieldRepository(_field);
            
            var aliveCellsCount = _repository.GetAliveCellsCountForPosition(new Point(0,0));
            
            Assert.AreEqual(7, aliveCellsCount);
        }
    }
}
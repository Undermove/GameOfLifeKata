using NUnit.Framework;

namespace GameOfLifeTests
{
    public class FieldRepositoryGetAliveCellsCountShould
    {
        [Test]
        public void ReturnNineAliveNeighboursCount_WhenPointInLeftUpperCorner_AndAllCellsAlive()
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

//        [TestCase(0, 1)]
//        public void ReturnEightAliveNeighboursCount_WhenPointInLeftUpperCorner_AndOneDeadCell(
//            int deadCellRow, 
//            int deadCellColumn)
//        {
//            char[,] _field =
//            {
//                {'*', '*', '*'},
//                {'*', '*', '*'},
//                {'*', '*', '*'}
//            };
//            _field[deadCellRow, deadCellColumn] = '.'; 
//            var _repository = new FieldRepository(_field);
//            
//            var aliveCellsCount = _repository.GetAliveCellsCount(new Point(0,0));
//            
//            Assert.AreEqual(8, aliveCellsCount);
//        }
    }
}
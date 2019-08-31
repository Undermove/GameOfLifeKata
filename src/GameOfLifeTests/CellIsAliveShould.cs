using Moq;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class CellIsAliveShould
    {
        [TestCase(0, false, false)]
        [TestCase(0, true, false)]
        [TestCase(1, true, false)]
        [TestCase(1, false, false)]
        [TestCase(2, true, true)]
        [TestCase(2, false, false)]
        [TestCase(3, false, true)]
        [TestCase(3, true, true)]
        [TestCase(4, true, false)]
        [TestCase(4, false, false)]
        public void ReturnTrue_WhenCallGenerateNewStateWithTwoAliveCellsAndAliveStateIsTrue(int aliveCells, bool isAliveState, bool expected)
        {
            Mock<IFieldRepository> fieldRepository = new Mock<IFieldRepository>();
            fieldRepository
                .Setup(repository => repository.GetAliveCellsCountForPosition(It.IsAny<Point>()))
                .Returns(aliveCells);
            Cell cell = new Cell(fieldRepository.Object, isAliveState, new Point());
            
            cell.GenerateNewState();
            
            Assert.AreEqual(expected, cell.IsAlive);
        }
    }
}
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class FieldRepositoryGetAliveCellsShould
    {
        [Test]
        public void ReturnOneAliveCell_WhenRawFieldContainsOneAliveCell()
        {
            char[,] rawField = {{'*'}}; 
            var repository = new FieldRepository(rawField);
            
            var aliveCellsCount = repository.GetAliveCellsCount();
            
            Assert.AreEqual(1, aliveCellsCount);
        }

        [Test]
        public void ReturnZeroAliveCells_WhenRAwFieldContainsOneDeadCell()
        {
            char[,] rawField = {{'.'}};
            var repository = new FieldRepository(rawField);
            
            var aliveCellsCount = repository.GetAliveCellsCount();
            
            Assert.AreEqual(0, aliveCellsCount);
        }
    }
}
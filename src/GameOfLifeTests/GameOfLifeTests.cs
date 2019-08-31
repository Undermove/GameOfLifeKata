using GameOfLifeLib;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class GameOfLife_NextGenerationTests
    {
        private GameOfLife _game;
        
        [SetUp]
        public void SetUp()
        {
            _game = new GameOfLife();
        }
        
        [Test]
        public void WhenOneAliveCell_ShouldReturnOneDeadCell()
        {
            var expected = "1,1\n.";
            
            var result = _game.GetNextGeneration("1,1\n*");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenOneDeadCell_ShouldReturnOneDeadCell()
        {
            var expected = "1,1\n.";
            
            var result = _game.GetNextGeneration("1,1\n.");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenOneDeadCellAndOneAliveCell_ShouldReturnTwoDeadCells()
        {
            var expected = "1,2\n..";

            var result = _game.GetNextGeneration("1,2\n.*");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenTwoDeadCells_ShouldReturnTwoDeadCells()
        {
            var expected = "1,2\n..";
            
            var result = _game.GetNextGeneration("1,2\n..");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenTwoAliveCells_ShouldReturnTwoAliveCells()
        {
            var expected = "1,2\n**";

            var result = _game.GetNextGeneration("1,2\n**");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenThreeAliveCells_ShouldReturnThreeAliveCell()
        {
            var expected = "1,3\n***";

            var result = _game.GetNextGeneration("1,3\n***");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenTwoDeadCellsAndOneAliveBetween_ShouldReturnThreeDeadCells()
        {
            var expected = "1,3\n...";

            var result = _game.GetNextGeneration("1,3\n.*.");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenTwoRowsWithAllDeadCells_ShouldReturnAllDeadCells()
        {
            var expected = "2,2\n....";

            var result = _game.GetNextGeneration("2,2\n....");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenTwoRowsWithOneAliveCell_ShouldReturnAllDeadCells()
        {
            var expected = "2,2\n....";

            var result = _game.GetNextGeneration("2,2\n*...");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenOneDeadThenThreeAliveCells_ShouldReturnOneAliveCell()
        {
            var expected = "1,4\n..*.";

            var result = _game.GetNextGeneration("1,4\n.***");
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenThreeAliveAndOneDeadCells_ShouldReturnOneAliveCell()
        {
            var expected = "1,4\n.*..";

            var result = _game.GetNextGeneration("1,4\n***.");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WhenThreeAliveAndOneDeadCellInOneColumn_ShouldReturnOneAliveCell()
        {
            var expected = "4,1\n.*..";

            var result = _game.GetNextGeneration("4,3\n.*..*..*..*.");
            
            Assert.AreEqual(expected, result);
        }
    }
}
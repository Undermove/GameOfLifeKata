using GameOfLifeLib;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class StringToFieldConverterTests
    {
        [Test]
        public void WhenOneToOneFieldWithDeadCell_ShouldReturnOneCellInArray()
        {
            int expectedRows = 1;
            int expectedColumns = 1;
            
            var result = StringToFieldConverter.ConvertToField("1,1",".");
            
            Assert.AreEqual(expectedRows, result.GetLength(0));
            Assert.AreEqual(expectedColumns, result.GetLength(1));
        }

        [Test]
        public void WhenOneColumnWithTwoRows_ShouldReturnArrayWithOneColumnAndTwoRows()
        {
            var result = StringToFieldConverter.ConvertToField("2,1", "..");
            
            Assert.AreEqual(2, result.GetLength(0));
            Assert.AreEqual(1, result.GetLength(1));
        }
        
        [Test]
        public void WhenOneColumnWithTwoRows_ShouldReturnDeadCellInFirstAndAliveCellInSecondRow()
        {
            var result = StringToFieldConverter.ConvertToField("2,1", ".*");
            
            Assert.AreEqual('.', result[0,0]);
            Assert.AreEqual('*', result[1,0]);
        }

        [Test]
        public void WhenOneRowWithTwoColumns_ShouldReturnDeadCellInFirstAndAliveCellInSecondColumn()
        {
            var result = StringToFieldConverter.ConvertToField("1,2", ".*");
            
            Assert.AreEqual('.', result[0,0]);
            Assert.AreEqual('*', result[0,1]);
        }

        [Test]
        public void WhenTwoRowWithTwoColumns_ShouldReturnDeadCellsInFirstRowAndInSecondRow()
        {
            var result = StringToFieldConverter.ConvertToField("2,2", "..**");
            
            Assert.AreEqual('.', result[0,0]);
            Assert.AreEqual('.', result[0,1]);
            Assert.AreEqual('*', result[1,0]);
            Assert.AreEqual('*', result[1,1]);
        }
    }
}
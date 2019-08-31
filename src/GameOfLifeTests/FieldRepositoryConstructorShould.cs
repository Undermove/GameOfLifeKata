using System;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class FieldRepositoryConstructorShould
    {
        [Test]
        public void ThrowArgumentException_WhenInvalidCharacterInRawField()
        {
            char[,] rawField = new char[1,1]{{'d'}};
         
            Assert.Throws<ArgumentException>(() => new FieldRepository(rawField));
        }
    }
}
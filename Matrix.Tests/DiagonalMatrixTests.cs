using NUnit.Framework;
using System;

namespace Matrix.Tests
{
    public class DiagonalMatrixTests
    {
        [Test]
        public void Create_SizePassed_Created()
        {
            var size = 3;
            var squareMatrix = new SquareMatrix<int>(size);
            Assert.AreEqual(size, squareMatrix.Size);
        }

        [Test]
        public void Create_DiagonalMatrixPassed_Created()
        {
            int[,] values = new int[,] { { 5, 0, 0 }, { 0, 5, 0 }, { 0, 0, 5 } };
            var matrix = new DiagonalMatrix<int>(values);
        }

        [Test]
        public void Create_NotDiagonalMatrixPassed_Created()
        {
            int[,] values = new int[,] { { 5, 0, 1 }, { 0, 5, 0 }, { 0, 0, 5 } };
            Assert.Throws<ArgumentException>
                (() => new DiagonalMatrix<int>(values));
        }

        [Test]
        public void Create_NullPassed_ThrowsArgumentNullException() => Assert.Throws<ArgumentNullException>
            (() => new DiagonalMatrix<int>(null));

        [Test]
        public void Create_NotPositiveSizePassed_ThrowsArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>
            (() => new DiagonalMatrix<int>(-2));
    }
}

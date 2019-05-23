using NUnit.Framework;
using System;

namespace Matrix.Tests
{
    public class SquareMatrixTests
    {
        [Test]
        public void Create_SizePassed_Created()
        {
            var size = 3;
            var squareMatrix = new SquareMatrix<int>(size);
            Assert.AreEqual(size, squareMatrix.Size);
        }

        [Test]
        public void Create_ArrayPassed_Created()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var squareMatrix = new SquareMatrix<int>(values);
            for (int i = 0; i < squareMatrix.Size; i++)
            {
                for (int j = 0; j < squareMatrix.Size; j++)
                {
                    Assert.AreEqual(values[i, j], squareMatrix[i, j]);
                }
            }
        }

        [Test]
        public void Create_NullPassed_ThrowsArgumentNullException() => Assert.Throws<ArgumentNullException>
                (() => new SquareMatrix<int>(null));

        [Test]
        public void Create_NotPositiveSizePassed_ThrowsArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>
                (() => new SquareMatrix<int>(-2));

        [Test]
        public void Create_NotSquareArrayPassed_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() =>
            new SquareMatrix<int>(new int[,] { { 1, 2 } }));

        [Test]
        public void Indexer_IndexIsGreaterThanSize_ThrowsArgumentOutOfRangeException()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var squareMatrix = new SquareMatrix<int>(values);
            Assert.Throws<ArgumentOutOfRangeException>(() => { int i = squareMatrix[5, 5]; } );
        }

        [Test]
        public void Indexer_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var squareMatrix = new SquareMatrix<int>(values);
            Assert.Throws<ArgumentOutOfRangeException>(() => { int i = squareMatrix[-1, 2]; });
        }

        [Test]
        public void Indexer_GetValue_ReturnValueFromMatrix()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var squareMatrix = new SquareMatrix<int>(values);
            Assert.AreEqual(5, squareMatrix[1, 1]);
        }

        [Test]
        public void Indexer_SetValue_ValueIsSetted()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var squareMatrix = new SquareMatrix<int>(values);
            squareMatrix[1, 1] = 222;
            Assert.AreEqual(222, squareMatrix[1, 1]);
        }
    }
}

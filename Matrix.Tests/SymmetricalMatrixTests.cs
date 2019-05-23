using NUnit.Framework;
using System;

namespace Matrix.Tests
{
    public class SymmetricalMatrixTests
    {
        [Test]
        public void Create_SizePassed()
        {
            var size = 3;
            var matrix = new SymmetricalMatrix<int>(size);
            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void Create_NullPassed_ThrowsArgumentNullException() => Assert.Throws<ArgumentNullException>
            (() => new SymmetricalMatrix<int>(null));

        [Test]
        public void Create_NotPositiveSizePassed_ThrowsArgumentOutOfRangeException() => Assert.Throws<ArgumentOutOfRangeException>
            (() => new SymmetricalMatrix<int>(-2));

        [Test]
        public void Create_NotSquareArrayPassed_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() =>
             new SymmetricalMatrix<int>(new int[,] { { 1, 2 } }));

        [Test]
        public void Create_SymmetricalMatrixPassed_Created()
        {
            int[,] values = new int[,] { { 1, 5 }, { 5, 7 } };
            var matrix = new SymmetricalMatrix<int>(values);
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(values[i, j], matrix[i, j]);
                }
            }
        }

        [Test]
        public void Create_NotSymmetricalMatrixPassed_Created()
        {
            int[,] values = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(values));
        }

        [Test]
        public void Indexer_GetValue_ReturnValueFromMatrix()
        {
            int[,] values = new int[,] { { 1, 5 }, { 5, 7 } };
            var matrix = new SquareMatrix<int>(values);
            Assert.AreEqual(7, matrix[1, 1]);
        }

        [Test]
        public void Indexer_SetValue_ValuesAreSetted()
        {
            int[,] values = new int[,] { { 1, 5 }, { 5, 7 } };
            var matrix = new SymmetricalMatrix<int>(values);
            matrix[0, 1] = 222;
            Assert.AreEqual(222, matrix[0, 1]);
            Assert.AreEqual(222, matrix[1, 0]);
        }
    }
}

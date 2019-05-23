using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixExtensions.Tests
{
    public class MatrixExtensionTests
    {
        [Test]
        public void Add_SizesNotEqual_ThrowsArgumentException()
        {
            var square = new SquareMatrix<int>(3);
            Assert.Throws<ArgumentException>(() => square.Add(new SymmetricalMatrix<int>(4)));
        }

        [Test]
        public void Add_TwoSquareMatrices_ReturnSquareMatrix()
        {
            var firstSquareMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var secondSquareMatrix = new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var result = firstSquareMatrix.Add(secondSquareMatrix);
            int[,] expectedValues = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void Add_SquareAndDiagonal_ReturnSquareMatrix()
        {
            var matrix = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var square = new SquareMatrix<int>(matrix);
            int[,] diagonal = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            var diagonalMatrix = new DiagonalMatrix<int>(diagonal);
            var result = square.Add(diagonalMatrix);
            int[,] expectedValues =
            {
                { 2, 2, 3 },
                { 4, 6, 6 },
                { 7, 8, 10 }
            };
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void Add_SquareAndSymmetrical_ReturnSquareMatrix()
        {
            var matrix = new int[,]
            {
                { 1, 2 },
                { 4, 5 }
            };
            var square = new SquareMatrix<int>(matrix);
            int[,] symmetrical = new int[,] { { 1, 5 }, { 5, 7 } };
            var diagonalMatrix = new SymmetricalMatrix<int>(symmetrical);
            var result = square.Add(diagonalMatrix);
            int[,] expectedValues =
            {
                { 2, 7 },
                { 9, 12 }
            };
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void Add_TwoDiagonalMatrices_ReturnDiagonalMatrix()
        {
            int[,] diagonal = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            var first = new DiagonalMatrix<int>(diagonal);
            var second = new DiagonalMatrix<int>(diagonal);
            var result = first.Add(second);
            int[,] expectedValues =
            {
                { 2, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 2 }
            };
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void Add_TwoSymmetricalMatrices_ReturnSymmetricalMatrix()
        {
            var matrix = new int[,]
            {
               { 11, 2, -8 },
               { 2, 2, 10 },
               { -8, 10, 5 }
            };
            var first = new SymmetricalMatrix<int>(matrix);
            var second = new SymmetricalMatrix<int>(matrix);
            var result = first.Add(second);
            var expectedValues = new int[,]
            {
               { 22, 4, -16 },
               { 4, 4, 20 },
               { -16, 20, 10 }
            };
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void Add_DiagonalAndSymmetricalMatrices_ReturnSymmetricalMatrix()
        {
            var valuesForSymmetrical = new int[,]
            {
               { 11, 2, -8 },
               { 2, 2, 10 },
               { -8, 10, 5 }
            };
            var valuesForDiagonal = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            var diagonalMatrix = new DiagonalMatrix<int>(valuesForDiagonal);
            var symmetricalMatrix = new SymmetricalMatrix<int>(valuesForSymmetrical);
            var expectedValues = new int[,]
            {
                { 12, 2, -8 },
                { 2, 3, 10 },
                { -8, 10, 6 }
            };
            var result = diagonalMatrix.Add(symmetricalMatrix);
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expectedValues[i, j], result[i, j]);
                }
            }
        }

        //addition via dynamic
        [Test]
        public void Add_TwoSquareMatricesString_ReturnSquareMatrix()
        {
            var values = new string[,]
            {
                { "first", "second" },
                { "1", "2" }
            };
            var first = new SquareMatrix<string>(values);
            var second = new SquareMatrix<string>(values);
            var expectedValues = new string[,]
            {
                { "firstfirst", "secondsecond" },
                { "11", "22" }
            };
            var result = first.Add(second);
        }

        [Test]
        public void Add_TwoDiagonalMatrices_ThrowsNotSupportedException()
        {
            var values = new string[,]
            {
                { "1", null, null },
                { null, "1", null },
                { null, null, "1" }
            };
            var first = new DiagonalMatrix<string>(values);
            var second = new DiagonalMatrix<string>(values);
            Assert.Throws<NotSupportedException>(() => first.Add(second));
        }

        [Test]
        public void Add_Two()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(int), "elem1"),
            paramB = Expression.Parameter(typeof(int), "elem2");
            BinaryExpression body = Expression.Add(paramA, paramB);
            Func<int, int, int> add = Expression
            .Lambda<Func<int, int, int>>(body, paramA, paramB)
            .Compile();
            var res =  add(5, 1);
        }

    } 
}

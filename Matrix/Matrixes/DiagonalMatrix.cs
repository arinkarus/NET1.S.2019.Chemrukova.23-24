using System;
using System.Collections.Generic;

namespace Matrix
{
    /// <summary>
    /// Represents diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Given type.</typeparam>
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Array that contains mainDiagonal values.
        /// </summary>
        private readonly T[] mainDiagonal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">Given size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
            this.mainDiagonal = new T[size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix">Given matrix.</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (!this.IsDiagonal(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} is not diagonal!");
            }

            this.mainDiagonal = new T[matrix.GetLength(0)];
            for (int i = 0; i < this.Size; i++)
            {
                this.mainDiagonal[i] = matrix[i, i];
            }
        }

        protected override T GetElement(int row, int column)
        {
            if (row != column)
            {
                return default(T);
            }

            return this.mainDiagonal[row];
        }

        protected override string GetMessage(T element, int row, int column)
        {
            return $"Diagonal Matrix Changed element, row = {row}, column = {column} to element with value = {element}";
        }

        protected override void SetElement(T value, int row, int column)
        {
            if (row != column)
            {
                throw new ArgumentException("Can't replace elements that are not on the main diagonal");
            }

            this.mainDiagonal[row] = value;
        }

        private bool IsDiagonal(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j && !EqualityComparer<T>.Default.Equals(matrix[i, j], matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

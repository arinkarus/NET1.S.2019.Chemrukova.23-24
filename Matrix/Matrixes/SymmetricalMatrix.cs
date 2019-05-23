using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Represents symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">Given type.</typeparam>
    public class SymmetricalMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Matrix array.
        /// </summary>
        private readonly T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}" /> class.
        /// </summary>
        /// <param name="size">Given size.</param>
        public SymmetricalMatrix(int size) : base(size)
        {
            this.matrix = new T[size, size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix">Given matrix.</param>
        public SymmetricalMatrix(T[,] matrix) : base(matrix)
        {
            if (!this.IsSymmetrical(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} is not symmetrical!");
            }

            this.matrix = matrix;
        }

        protected override T GetElement(int row, int column)
        {
            return this.matrix[row, column];
        }

        protected override void SetElement(T value, int row, int column)
        {
            this.matrix[row, column] = value;
            this.matrix[column, row] = value;
        }
      
        protected override string GetMessage(T element, int row, int column)
        {
            return $"Symmetrical Matrix Changed element, row = {row}, column = {column} to element with value = {element}";
        }

        private bool IsSymmetrical(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(matrix[i, j], matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}

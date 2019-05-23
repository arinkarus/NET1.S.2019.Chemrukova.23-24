using System;

namespace Matrix
{
    /// <summary>
    /// Base matrix for matrixes.
    /// </summary>
    /// <typeparam name="T">Given type.</typeparam>
    public abstract class BaseMatrix<T>
    {
        /// <summary>
        /// Size of matrix.
        /// </summary>
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}" /> class.
        /// </summary>
        /// <param name="size">Given size.</param>
        public BaseMatrix(int size)
        {
            this.Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix">Given matrix.</param>
        public BaseMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} cannot be null!");
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException($"Passed matrix should be square {nameof(matrix)}");
            }

            this.Size = matrix.GetLength(0);
        }

        /// <summary>
        /// Event for element changing.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs> ElementChanged;

        /// <summary>
        /// Gets or sets size of matrix.
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Size can't be null {nameof(value)}");
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Gets or sets matrix element on specified row and column.
        /// </summary>
        /// <param name="row">Specified row.</param>
        /// <param name="column">Specified column.</param>
        /// <returns>Matrix element.</returns>
        public virtual T this[int row, int column]
        {
            get
            {
                CheckIndexBounds(row, column);
                return this.GetElement(row, column);
            }

            set
            {
                CheckIndexBounds(row, column);
                SetElement(value, row, column);
                string message = this.GetMessage(value, row, column);
                this.OnElementChanged(new ElementChangedEventArgs()
                    { Message = message });
            }
        }

        protected abstract string GetMessage(T element, int row, int column);

        protected abstract T GetElement(int row, int column);

        protected abstract void SetElement(T value, int row, int column);

        protected virtual void OnElementChanged(ElementChangedEventArgs eventArgs)
        {
            this.ElementChanged?.Invoke(this, eventArgs);
        }

        private void CheckIndexBounds(int row, int column)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException($"Row can't be less than one!");
            }

            if (column < 0)
            {
                throw new ArgumentOutOfRangeException($"Column can't be less than one!");
            }

            if (row >= this.Size || column >= this.Size)
            {
                throw new ArgumentOutOfRangeException($"Specified value is greater than matrix real size!");
            }
        }
    }
}

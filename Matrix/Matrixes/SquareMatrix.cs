namespace Matrix
{
    /// <summary>
    /// Represents square matrix.
    /// </summary>
    /// <typeparam name="T">Given type.</typeparam>
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Matrix array.
        /// </summary>
        private readonly T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}" /> class.
        /// </summary>
        /// <param name="size">Given size.</param>
        public SquareMatrix(int size) : base(size)
        {
            this.matrix = new T[size, size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix">Given matrix.</param>
        public SquareMatrix(T[,] matrix): base(matrix)
        {
            this.matrix = (T[,])matrix.Clone();
        }

        protected override T GetElement(int row, int column)
        {
            return this.matrix[row, column];
        }

        protected override void SetElement(T value, int row, int column)
        {
            matrix[row, column] = value;
        }

        protected override string GetMessage(T element, int row, int column)
        {
            return $"Square Matrix Changed element, row = {row}, column = {column} to element with value = {element}";
        }
    }
}

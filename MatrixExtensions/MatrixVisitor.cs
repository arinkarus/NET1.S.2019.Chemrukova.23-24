using Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtensions
{
    public abstract class MatrixVisitor<T>
    {
        public BaseMatrix<T> DymanicVisit(BaseMatrix<T> lhs, BaseMatrix<T> rhs)
        {
            return Visit((dynamic)lhs, (dynamic)rhs);
        }

        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> lhs, SquareMatrix<T> rhs);

        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs);

        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> lhs, SymmetricalMatrix<T> rhs);

        protected abstract DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs);

        protected abstract SquareMatrix<T> Visit(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs);

        protected abstract SymmetricalMatrix<T> Visit(DiagonalMatrix<T> lhs, SymmetricalMatrix<T> rhs);

        protected abstract SymmetricalMatrix<T> Visit(SymmetricalMatrix<T> lhs, SymmetricalMatrix<T> rhs);

        protected abstract SymmetricalMatrix<T> Visit(SymmetricalMatrix<T> lhs, DiagonalMatrix<T> rhs);

        protected abstract SquareMatrix<T> Visit(SymmetricalMatrix<T> lhs, SquareMatrix<T> rhs);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Microsoft.CSharp.RuntimeBinder;

namespace MatrixExtensions
{
    public class SumVisitor<T> : MatrixVisitor<T>
    {
        protected override SquareMatrix<T> Visit(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            SquareMatrix<T> squareMatrix = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    squareMatrix[i, j] = AddViaDynamic(lhs[i, j], rhs[i, j]);
                }

            }

            return squareMatrix;
        }

        protected override SquareMatrix<T> Visit(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            SquareMatrix<T> squareMatrix = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    squareMatrix[i, j] = AddViaDynamic(lhs[i, j], rhs[i, j]);
                }
            }

            return squareMatrix;
        }

        protected override SquareMatrix<T> Visit(SquareMatrix<T> lhs, SymmetricalMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            SquareMatrix<T> squareMatrix = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    squareMatrix[i, j] = AddViaDynamic(lhs[i, j], rhs[i, j]);
                }
            }

            return squareMatrix;
        }

        protected override DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            DiagonalMatrix<T> diagonalMatrix = new DiagonalMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                diagonalMatrix[i, i] = AddViaExpression(lhs[i, i], rhs[i, i]);
            }

            return diagonalMatrix;

        }

        protected override SquareMatrix<T> Visit(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            return Visit(rhs, lhs);
        }

        protected override SymmetricalMatrix<T> Visit(DiagonalMatrix<T> lhs, SymmetricalMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            SymmetricalMatrix<T> symmetricalMatrix = new SymmetricalMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    symmetricalMatrix[i, j] = AddViaDynamic(lhs[i, j], rhs[i, j]);
                }
            }

            return symmetricalMatrix;
        }

        protected override SymmetricalMatrix<T> Visit(SymmetricalMatrix<T> lhs, SymmetricalMatrix<T> rhs)
        {
            this.Validate(lhs, rhs);
            SymmetricalMatrix<T> symmetricalMatrix = new SymmetricalMatrix<T>(rhs.Size);
            for (int i = 0; i < rhs.Size; i++)
            {
                for (int j = 0; j < rhs.Size; j++)
                {
                    symmetricalMatrix[i, j] = AddViaDynamic(lhs[i, j], rhs[i, j]);
                }
            }

            return symmetricalMatrix;
        }

        protected override SymmetricalMatrix<T> Visit(SymmetricalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            return Visit(rhs, lhs);
        }

        protected override SquareMatrix<T> Visit(SymmetricalMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            return Visit(rhs, lhs);
        }

        private void Validate(BaseMatrix<T> lhs, BaseMatrix<T> rhs)
        {
            if (lhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} cannot be null");
            }

            if (rhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} cannot be null");
            }

            if (lhs.Size != rhs.Size)
            {
                throw new ArgumentException("Sizes of matrixes have to be equal!");
            }
        }

        private T AddViaDynamic<T>(T lhs, T rhs)
        {
            T result;
            try
            {
                result = (dynamic)lhs + rhs;
            }
            catch (RuntimeBinderException)
            {
                throw new NotSupportedException($"Can't add {lhs.GetType().Name} and {rhs.GetType().Name}");
            }
            return result;
        }

        private T AddViaExpression(T lhs, T rhs)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "elem1"),
            paramB = Expression.Parameter(typeof(T), "elem2");
            try { 
                BinaryExpression body = Expression.Add(paramA, paramB);
                Func<T, T, T> add = Expression
                .Lambda<Func<T, T, T>>(body, paramA, paramB)
                .Compile();
                var result = add(lhs, rhs);
                return result;
            }
            catch (InvalidOperationException)
            {
                throw new NotSupportedException($"Can't add {lhs.GetType().Name} and {rhs.GetType().Name}");
            }
        }
    }
}

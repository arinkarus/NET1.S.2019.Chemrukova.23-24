using Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtensions
{
    public static class MatrixExtension
    {
        public static BaseMatrix<T> Add<T>(this BaseMatrix<T> m1, BaseMatrix<T> m2)
        {
            var visitor = new SumVisitor<T>();
            return visitor.DymanicVisit(m1, m2);
        }
    }
}

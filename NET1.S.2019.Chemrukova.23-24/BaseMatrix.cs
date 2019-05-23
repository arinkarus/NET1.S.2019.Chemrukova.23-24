using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Chemrukova._23_24
{
    public abstract class BaseMatrix<T> : IEnumerable<T>
    {
        private int size;

        public int Size
        {
            get { return this.size; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Size can't be null {nameof(value)}");
                }
            }
        }

        public BaseMatrix(int size)
        {
            this.Size = size;
        }

        public event EventHandler<>

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

using System;
using System.Text;

namespace CustomArray
{
    /// <summary>
    /// A <see cref="Custom2DArray{T}"/> that acts like a 2d array but really is just a 1d array under the hood.
    /// </summary>
    /// <typeparam name="T">Whatever you want bud.</typeparam>
    public class Custom2DArray<T>
    {
        /// <summary>
        /// The underling 1d array.
        /// </summary>
        private T[] UnderlyingArray { get; set; }
        /// <summary>
        /// Gets the Length of the underlying array.
        /// </summary>
        public int Length => UnderlyingArray.Length;
        /// <summary>
        /// Gets the column count assigned in the constructor.
        /// </summary>
        public int ColumnCount { get; private set; }
        /// <summary>
        /// Gets the row count assigned in teh constructor.
        /// </summary>
        public int RowCount { get; private set; }
        /// <summary>
        /// Initializes a new <see cref="Custom2DArray{T}"/> instance.
        /// </summary>
        /// <param name="_rowCount"></param>
        /// <param name="_columnCount"></param>
        public Custom2DArray(int _rowCount, int _columnCount)
        {
            RowCount = _rowCount;
            ColumnCount = _columnCount;
            UnderlyingArray = new T[_rowCount * _columnCount];
        }
        /// <summary>
        /// Sets the given value at the specified location. Will throw an exception if either of the provided index values are out of bounds.
        /// </summary>
        /// <param name="row">Row in array.</param>
        /// <param name="column">Column in array.</param>
        /// <param name="value">Value to be assigned.</param>
        public void SetAt(int row, int column, T value)
            => UnderlyingArray[row * ColumnCount + column] = value;
        /// <summary>
        /// Gets the <see cref="T"/> residing at the specified <paramref name="row"/> and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row to target.</param>
        /// <param name="column">The column to target.s</param>
        /// <returns></returns>
        public T GetAt(int row, int column)
            => UnderlyingArray[row * ColumnCount + column];
    }
}

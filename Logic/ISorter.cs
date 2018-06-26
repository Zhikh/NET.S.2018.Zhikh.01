using System;

namespace Logic
{
    /// <summary>
    /// This interface is used for various types of sorting.
    /// </summary>
    public interface ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// This method sorts array of type T.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        void Sort(T[] array);
    }
}

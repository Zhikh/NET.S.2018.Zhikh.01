﻿namespace Logic
{
    using System;

    /// <summary>
    /// This interface is used for various types of sorting.
    /// </summary>
    public interface ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// This method sorts array of type T.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <returns> Sorted array </returns>
        T[] Sort(T[] array);
    }
}

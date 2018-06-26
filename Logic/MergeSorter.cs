using System;
using System.Linq; 

namespace Logic
{
    /// <summary>
    /// This class imlements interface ISorter<T> for Merge sort.
    /// </summary>
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        #region Public Methods
        /// <summary>
        /// This method sorts array of type T using merge sort.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <exception> ArgumentNullException </exception>
        public void Sort(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            var sortedArray = SplitArray(elements);

            sortedArray.CopyTo(elements, 0);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method spits array, sorts its parts and merges them.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <returns> Merged array </returns>
        /// <exception> ArgumentNullException </exception>
        private T[] SplitArray(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            if (elements.Length == 1)
            {
                return elements;
            }

            var middle = elements.Length / 2;

            // partitioning array to the smallest parts
            // sort these parts and merge it
            return MergeSort(SplitArray(elements.Take(middle).ToArray()), SplitArray(elements.Skip(middle).ToArray()));
        }

        /// <summary>
        /// This method merges array with sorting its elements between each.
        /// </summary>
        /// <param name="leftPart"> Left part of array </param>
        /// <param name="rightPart"> Right part of array </param>
        /// <returns> Merged array </returns>
        /// <exception> ArgumentNullException </exception>
        private T[] MergeSort(T[] leftPart, T[] rightPart)
        {
            if (leftPart == null || rightPart == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            var length = leftPart.Length + rightPart.Length;
            var result = new T[length];

            int j = 0;
            int k = 0;

            for (var i = 0; i < length; i++)
            {
                // checking range of subarrays
                if (j == leftPart.Length || k == rightPart.Length)
                {
                    if (j == leftPart.Length)
                    {
                        result[i] = rightPart[k++];
                    }
                    else
                    {
                        result[i] = leftPart[j++];
                    }
                }
                else
                {
                    if (leftPart[j].CompareTo(rightPart[k]) > 0)
                    {
                        result[i] = rightPart[k++];
                    }
                    else
                    {
                        result[i] = leftPart[j++];
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
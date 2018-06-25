namespace Logic
{
    using System;
    using System.Linq;

    /// <summary>
    /// This class imlements interface ISorter<T> for Merge sort.
    /// </summary>
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// This method separates and sorts arrays of type T.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <returns> Sorted array </returns>
        public T[] Sort(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentException("Argument can't be null!");
            }

            if (elements.Length == 1)
            {
                return elements;
            }

            var middle = elements.Length / 2;

            // partitioning array to the smallest parts
            // sort these parts and merge it
            return this.MergeSort(Sort(elements.Take(middle).ToArray()), Sort(elements.Skip(middle).ToArray()));
        }

        /// <summary>
        /// This method merges array with sorting its elements between each.
        /// </summary>
        /// <param name="leftPart"> Left part of array </param>
        /// <param name="rightPart"> Right part of array </param>
        /// <returns> Merged array </returns>
        private T[] MergeSort(T[] leftPart, T[] rightPart)
        {
            if (leftPart == null || rightPart == null)
            {
                throw new ArgumentException("Argument can't be null!");
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
                        result[i] = rightPart[k++];
                    else
                        result[i] = leftPart[j++];
                }
                else
                {
                    if (leftPart[j].CompareTo(rightPart[k]) > 0)
                        result[i] = rightPart[k++];
                    else
                        result[i] = leftPart[j++];
                }
            }

            return result;
        }
    }
}
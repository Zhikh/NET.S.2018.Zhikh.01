using System;

namespace Logic
{
    /// <summary>
    /// This class imlements interface ISorter<T> for QuickSort.
    /// </summary>
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// This method sorts array of type T.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <exception> ArgumentNullException </exception>
        public void Sort(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }
            
            QuickSort(elements, elements.Length - 1);
        }

        /// <summary>
        /// This method sorts array of type T by pivot element.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <param name="endIndex"> Last index of subarray </param>
        /// <param name="startIndex"> First index of subarray </param>
        /// <param name="i"> Last index for left subarray </param>
        /// <param name="j"> First index for right subarray </param>
        /// <exception> ArgumentNullException </exception>
        private static void SplitArray(out int i, out int j, T[] array, int endIndex, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            T pivot = array[(endIndex + startIndex) / 2];

            i = startIndex;
            j = endIndex;

            do
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i, j);

                    i++;
                    j--;
                }
            }
            while (i <= j);
        }

        /// <summary>
        /// This method swaps elements of array.
        /// </summary>
        /// <param name="array"> Array for exchange </param>
        /// <param name="i"> Index for exchange </param>
        /// <param name="j"> Index for exchange </param>
        /// <exception> ArgumentNullException </exception>
        private static T Swap(T[] array, int i, int j)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            T temp = array[i];

            array[i] = array[j];
            array[j] = temp;

            return temp;
        }

        /// <summary>
        /// This method sorts array of type T.
        /// </summary>
        /// <param name="array"> Unsorted array of type T </param>
        /// <param name="endIndex"> Last index of subarray </param>
        /// <param name="startIndex"> First index of subarray </param>
        /// <exception> ArgumentNullException </exception>
        private void QuickSort(T[] array, int endIndex, int startIndex = 0)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            int i, j;

            SplitArray(out i, out j, array, endIndex, startIndex);

            if (j > startIndex)
            {
                QuickSort(array, j, startIndex);
            }

            if (endIndex > i)
            {
                QuickSort(array, endIndex, i);
            }
        }
    }
}

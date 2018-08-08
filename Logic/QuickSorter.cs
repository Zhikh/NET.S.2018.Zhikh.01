using System;

namespace Logic
{
    /// <summary>
    /// This class imlements interface ISorter<T> for QuickSort.
    /// </summary>
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        #region Public Methods
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
        #endregion

        #region Private Methods
        private static void SplitArray(out int i, out int j, T[] array, int endIndex, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            if ((startIndex < 0) || (startIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((endIndex < 0) || (endIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
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
                    Swap(ref array[i], ref array[j]);

                    i++;
                    j--;
                }
            }
            while (i <= j);
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;

            first = second;
            second = first;
        }
        
        private void QuickSort(T[] array, int endIndex, int startIndex = 0)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            if ((startIndex < 0) || (startIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((endIndex < 0) || (endIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
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
        #endregion
    }
}

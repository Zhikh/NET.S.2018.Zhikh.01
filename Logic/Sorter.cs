using System;
using System.Linq;

namespace Logic
{
    public static class Sorter
    {
        #region Public API
        public static void MergeSorter<T>(T[] elements, Comparison<T> comparison)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            var sortedArray = SplitArrayForMergeSort(elements, comparison);

            sortedArray.CopyTo(elements, 0);
        }

        public static void QuickSorter<T>(T[] elements, Comparison<T> comparison)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            QuickSort(elements, comparison, elements.Length - 1);
        }
        #endregion

        #region Additional methods
        private static T[] SplitArrayForMergeSort<T>(T[] elements, Comparison<T> comparison)
        {
            if (elements.Length == 1)
            {
                return elements;
            }

            var middle = elements.Length / 2;
            
            return MergeSort(SplitArrayForMergeSort(elements.Take(middle).ToArray(), comparison), 
                SplitArrayForMergeSort(elements.Skip(middle).ToArray(), comparison), comparison);
        }

        private static T[] MergeSort<T>(T[] leftPart, T[] rightPart, Comparison<T> comparison)
        {
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
                    if (comparison(leftPart[j], rightPart[k]) > 0)
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

        private static void QuickSort<T>(T[] array, Comparison<T> comparison, int endIndex, int startIndex = 0)
        {
            if ((startIndex < 0) || (startIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((endIndex < 0) || (endIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException();
            }

            int i, j;

            SplitArrayQuickSort(comparison, out i, out j, array, endIndex, startIndex);

            if (j > startIndex)
            {
                QuickSort(array, comparison, j, startIndex);
            }

            if (endIndex > i)
            {
                QuickSort(array, comparison, endIndex, i);
            }
        }

        private static void SplitArrayQuickSort<T>(Comparison<T> comparison, out int i, out int j, T[] array, int endIndex, int startIndex)
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
                while (comparison(array[i], pivot) < 0)
                {
                    i++;
                }

                while (comparison(array[j], pivot) > 0)
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
        #endregion
    }
}

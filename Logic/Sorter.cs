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
                throw new ArgumentNullException("Argument can't be null!");
            }

            var sortedArray = SplitArray(elements, comparison);

            sortedArray.CopyTo(elements, 0);
        }

        public static void QuickSorter<T>(T[] elements) where T : IComparable<T>
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }
        }
        #endregion

        #region Additional methods
        private static T[] SplitArray<T>(T[] elements, Comparison<T> comparison)
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
            
            return MergeSort(SplitArray(elements.Take(middle).ToArray(), comparison), 
                SplitArray(elements.Skip(middle).ToArray(), comparison), comparison);
        }

        private static T[] MergeSort<T>(T[] leftPart, T[] rightPart, Comparison<T> comparison)
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
        #endregion
    }
}

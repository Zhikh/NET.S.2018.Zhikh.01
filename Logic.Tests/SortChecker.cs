using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    public static class SortChecker
    {
        #region Public methods
        /// <summary>
        /// This method is for checking work of sort.
        /// </summary>
        /// <param name="sorter"> Object for sort of inrerface of ISorter<int> </param>
        /// <exception cref="ArgumentNullException"> Trow when sorter = null </exception>
        public static void CheckSort(ISorter<int> sorter)
        {
            if (sorter == null)
            {
                throw new ArgumentNullException("Argument can't be null!");
            }

            int[] amounts = new[] { 5000, 10000, 50000, 100000, 500000, 1000000 };

            foreach (var n in amounts)
            {
                int range = 10;
                int[] array = SortChecker.GenerateIntValues(n, range);

                int[] expected = new int[n];

                SortChecker.SortArrays(sorter, array, expected);

                CollectionAssert.AreEqual(array, expected);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// This method generates random integer values.
        /// </summary>
        private static int[] GenerateIntValues(int n, int range)
        {
            var result = new int[n];
            var rng = new Random(range);

            for (int i = 0; i < n; ++i)
            {
                result[i] = rng.Next();
            }

            return result;
        }

        /// <summary>
        /// This method is for checking work of sort.
        /// </summary>
        private static void SortArrays<T>(ISorter<T> sorter, T[] array, T[] expected) where T : IComparable<T>
        {
            array.CopyTo(expected, 0);

            Array.Sort(expected);

            sorter.Sort(array);
        }
        #endregion
    }
}

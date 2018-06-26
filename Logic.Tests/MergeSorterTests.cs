using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_ReturnArgumentException()
        {
            int[] array = null;

            var sorter = new MergeSorter<int>();

            sorter.Sort(array);
        }

        [TestMethod]
        public void Sort_IntArray_ReturnSortedArray()
        {
            int[] array = { 1, 6, 45, 6, 5, 35 };
            int[] expected = { 1, 5, 6, 6, 35, 45 };

            var sorter = new MergeSorter<int>();

            sorter.Sort(array);

            CollectionAssert.AreEqual(array, expected);
        }
    }
}

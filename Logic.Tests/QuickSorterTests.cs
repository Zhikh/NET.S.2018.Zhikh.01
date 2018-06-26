using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class QuickSorterTests
    {
        [TestMethod]
        public void Sort_IntArray_ReturnSortedArray()
        {
            int[] array = { 1, 6, 45, 6, 5, 35 };
            int[] expected = { 1, 5, 6, 6, 35, 45 };

            var sorter = new QuickSorter<int>();

            sorter.Sort(array);

            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void Sort_StringArray_ReturnSortedArray()
        {
            string[] array = { "fgh", "a", "", "b", "fga", "" };
            string[] expected = {"", "",  "a", "b", "fga", "fgh"};

            var sorter = new QuickSorter<string>();

            sorter.Sort(array);

            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_ReturnArgumentException()
        {
            int[] array = null;

            var sorter = new QuickSorter<int>();

            sorter.Sort(array);
        }
    }
}

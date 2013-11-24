using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SortsLibrary;

namespace SortsTests
{
    [TestClass]
    public class QuickInPlaceSortTests
    {
        private bool CompareArrays(int[] original, int[] sorted)
        {
            if (original.Length != sorted.Length)
                return false;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != sorted[i]) return false;
            }

            return true;
        }

        [TestMethod]
        public void OneElementArray()
        {
            var originalArray = new[] { 1 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(originalArray, res.SortedArray));
        }

        [TestMethod]
        public void TwoAscElementArray()
        {
            var originalArray = new[] { 1, 2 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(originalArray, res.SortedArray));
        }

        [TestMethod]
        public void TwoEqualsElementArray()
        {
            var originalArray = new[] { 1, 1 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(originalArray, res.SortedArray));
        }

        [TestMethod]
        public void TwoDescElementArray()
        {
            var originalArray = new[] { 2, 1 };
            var expectedArray = new[] { 1, 2 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(expectedArray, res.SortedArray));
        }

        [TestMethod]
        public void SortSortedAscArray()
        {
            var originalArray = new[] { 1, 2, 3, 4, 5, 6 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(originalArray, res.SortedArray));
        }

        [TestMethod]
        public void SortSortedDescArray()
        {
            var resultArray = new[] { 1, 2, 3, 4, 5, 6 };
            var originalArray = new[] { 6, 5, 4, 3, 2, 1 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(resultArray, res.SortedArray));
        }

        [TestMethod]
        public void SortRandomArray()
        {
            var resultArray = new[] { 1, 2, 3, 4, 5, 6 };
            var originalArray = new[] { 6, 4, 2, 3, 5, 1 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(resultArray, res.SortedArray));
        }

        [TestMethod]
        public void SortRandomArraySeven()
        {
            var resultArray = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var originalArray = new[] { 6, 4, 2, 3, 7, 5, 1 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(resultArray, res.SortedArray));
        }

        [TestMethod]
        public void SortArrayWithDuplicates()
        {
            var resultArray = new[] { 2, 3, 3, 4, 4, 6 };
            var originalArray = new[] { 6, 4, 2, 3, 4, 3 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(resultArray, res.SortedArray));
        }

        [TestMethod]
        public void SortArrayWithDuplicatesSeven()
        {
            var resultArray = new[] { 2, 3, 3, 4, 4, 6, 7};
            var originalArray = new[] { 6, 4, 2, 7, 3, 4, 3 };
            var res = Sorts.QuickInPlace(originalArray);
            Assert.IsTrue(CompareArrays(resultArray, res.SortedArray));
        }
    }
}

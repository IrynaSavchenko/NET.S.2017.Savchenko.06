using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    public class ArraySortingTests
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new[]
                {
                    new[] {1, 3, 21, -11, -5},
                    new[] {-22, 10, -3},
                    new[] {15, 43},
                    new[] {3, -9, 20, 18}
                }, new[]
                {
                    new[] {-22, 10, -3},
                    new[] {1, 3, 21, -11, -5},
                    new[] {3, -9, 20, 18},
                    new[] {15, 43}
                });
            }
        }

        #region Sum In Rows

        [Test, TestCaseSource(nameof(TestData))]
        public void Sort_Array_ArraySortedByRowsAscendingSum(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, ComparerType.SumInRows);
            IStructuralEquatable structEq = array;
            CheckArraysForEquality(array, sortedArray);
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Sort_Array_ArraySortedByRowsDescendingSum(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, ComparerType.SumInRows, false);
            Array.Reverse(sortedArray);
            CheckArraysForEquality(array, sortedArray);
        }

        #endregion

        private void CheckArraysForEquality(int[][] firstArray, int[][] secondArray)
        {
            IStructuralEquatable structEq = firstArray;
            Assert.True(structEq.Equals(secondArray, StructuralComparisons.StructuralEqualityComparer));
        }
    }
}

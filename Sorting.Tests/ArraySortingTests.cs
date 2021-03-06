﻿using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sorting.Tests.Comparers;

namespace Sorting.Tests
{
    [TestFixture]
    public class ArraySortingTests
    {
        private static int[][] TestData => new[]
        {
            new[] {1, 3, 21, -11, -5},
            new[] {-22, 10, -3},
            new[] {15, 43},
            new[] {3, -9, 20, 18}
        };

        #region Sum In Rows

        private static IEnumerable<TestCaseData> SumTestData
        {
            get
            {
                yield return new TestCaseData(TestData,
                new[]
                {
                    new[] {-22, 10, -3},
                    new[] {1, 3, 21, -11, -5},
                    new[] {3, -9, 20, 18},
                    new[] {15, 43}
                });
            }
        }

        [Test, TestCaseSource(nameof(SumTestData))]
        public void Sort_Array_ArraySortedByRowsAscendingSum(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new SumInRowsAscendingComparer());
            CheckArraysForEquality(array, sortedArray);
        }

        [Test, TestCaseSource(nameof(SumTestData))]
        public void Sort_Array_ArraySortedByRowsDescendingSum(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new SumInRowsDescendingComparer());
            Array.Reverse(sortedArray);
            CheckArraysForEquality(array, sortedArray);
        }

        #endregion

        #region Max In Rows

        private static IEnumerable<TestCaseData> MaxTestData
        {
            get
            {
                yield return new TestCaseData(TestData, new[]
                {
                    new[] {-22, 10, -3},
                    new[] {3, -9, 20, 18},
                    new[] {1, 3, 21, -11, -5},
                    new[] {15, 43}
                });
            }
        }

        [Test, TestCaseSource(nameof(MaxTestData))]
        public void Sort_Array_ArraySortedByRowsAscendingMax(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new MaxInRowsAscendingComparer());
            CheckArraysForEquality(array, sortedArray);
        }
        [Test, TestCaseSource(nameof(MaxTestData))]
        public void Sort_Array_ArraySortedByRowsDescendingMax(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new MaxInRowsDescendingComparer());
            Array.Reverse(sortedArray);
            CheckArraysForEquality(array, sortedArray);
        }

        #endregion

        #region Min In Rows

        private static IEnumerable<TestCaseData> MinTestData
        {
            get
            {
                yield return new TestCaseData(TestData, new[]
                {
                    new[] {-22, 10, -3},
                    new[] {1, 3, 21, -11, -5},
                    new[] {3, -9, 20, 18},
                    new[] {15, 43}
                });
            }
        }

        [Test, TestCaseSource(nameof(MinTestData))]
        public void Sort_Array_ArraySortedByRowsAscendingMin(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new MinInRowsAscendingComparer());
            CheckArraysForEquality(array, sortedArray);
        }
        [Test, TestCaseSource(nameof(MinTestData))]
        public void Sort_Array_ArraySortedByRowsDescendingMin(int[][] array, int[][] sortedArray)
        {
            ArraySorting.Sort(array, new MinInRowsDescendingComparer());
            Array.Reverse(sortedArray);
            CheckArraysForEquality(array, sortedArray);
        }

        #endregion

        #region Exception

        [TestCase(null)]
        public void Sort_NullArray_ThrowsArgumentNullException(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => ArraySorting.Sort(array, new SumInRowsAscendingComparer()));
        }

        private static IEnumerable<TestCaseData> NullTestData
        {
            get
            {
                yield return new TestCaseData(new[]
                {
                    new[] {-22, 10, -3},
                    null
                }, 
                null);
            }
        }

        [Test, TestCaseSource(nameof(NullTestData))]
        public void Sort_ArrayWithNullRows_ThrowsArgumentNullException(int[][] array, int[][] result)
        {
            Assert.Throws<ArgumentNullException>(() => ArraySorting.Sort(array, new MaxInRowsAscendingComparer()));
        }

        #endregion

        private void CheckArraysForEquality(int[][] firstArray, int[][] secondArray)
        {
            IStructuralEquatable structEq = firstArray;
            Assert.True(structEq.Equals(secondArray, StructuralComparisons.StructuralEqualityComparer));
        }
    }
}

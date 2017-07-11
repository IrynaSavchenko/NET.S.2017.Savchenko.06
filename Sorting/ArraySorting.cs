using System;

namespace Sorting
{
    /// <summary>
    /// Used for sorting rows in jagged arrays according to the defined criteria
    /// </summary>
    public static class ArraySorting
    {
        /// <summary>
        /// Sorts rows in the array according to the defined criteria
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparerType">Criteria for sorting rows</param>
        /// <param name="ascending">Defines sorting order: ascending or descending</param>
        public static void Sort(int[][] array, ComparerType comparerType, bool ascending = true)
        {
            CheckArray(array);
            PerformSort(array, comparerType, ascending);
        }

        private static void PerformSort(int[][] array, ComparerType comparerType, bool ascending)
        {
            bool swapped = true;
            for (int i = array.Length - 1; swapped && i > 0; i--)
            {
                swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (IsProperlyOrdered(array[j], array[j + 1], comparerType, ascending)) continue;

                    Swap(ref array[j], ref array[j + 1]);
                    swapped = true;
                }
            }
        }

        private static bool IsProperlyOrdered(int[] firstArray, int[] secondArray, ComparerType comparerType,
            bool ascending)
        {
            int comparisonResult = comparerType.Compare(firstArray, secondArray);
            if (comparisonResult == 0)
            {
                return true;
            }
            return ascending ^ (comparisonResult > 0);
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        private static void CheckArray(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} cannot be null");
        }
    }
}

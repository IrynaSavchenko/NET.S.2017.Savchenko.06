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
        /// <param name="comparer">Comparer for defining row order</param>
        public static void Sort(int[][] array, IComparer comparer)
        {
            CheckArray(array);
            PerformSort(array, comparer);
        }

        private static void PerformSort(int[][] array, IComparer comparer)
        {
            bool swapped = true;
            for (int i = array.Length - 1; swapped && i > 0; i--)
            {
                swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) <= 0) continue;

                    Swap(ref array[j], ref array[j + 1]);
                    swapped = true;
                }
            }
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

            if (Array.Exists(array, row => row == null))
                throw new ArgumentNullException($"{nameof(array)} elements cannot be null");
        }
    }
}

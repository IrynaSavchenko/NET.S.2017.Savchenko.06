using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Factory containing extension methods for ComparerType
    /// </summary>
    public static class ComparerTypeFactory
    {
        private static readonly IDictionary<ComparerType, Func<int[], int>> ComparersFactory = 
            new Dictionary<ComparerType, Func<int[], int>>
        {
            {ComparerType.SumInRows, array => array.Sum()},
            {ComparerType.MaxInRows, array => array.Max()},
            {ComparerType.MinInRows, array => array.Min()}
        };

        /// <summary>
        /// Compares firstArray with secondArray according to comparerType
        /// </summary>
        /// <param name="comparerType">Criteria for sorting rows</param>
        /// <param name="firstArray">First array to be compared</param>
        /// <param name="secondArray">Second array to be compared</param>
        /// <returns>Result of comparing firstArray with secondArray</returns>
        public static int Compare(this ComparerType comparerType, int[] firstArray, int[] secondArray)
        {
            CheckArgumentsForNull(firstArray, secondArray);
            
            Func<int[], int> comparerFunc = ComparersFactory[comparerType];
            return comparerFunc(firstArray).CompareTo(comparerFunc(secondArray));
        }

        private static void CheckArgumentsForNull(int[] x, int[] y)
        {
            CheckArrayForNull(x, nameof(x));
            CheckArrayForNull(y, nameof(y));
        }

        private static void CheckArrayForNull(int[] array, string argName)
        {
            if (array == null)
                throw new ArgumentNullException($"{argName} cannot be null");
        }
    }
}

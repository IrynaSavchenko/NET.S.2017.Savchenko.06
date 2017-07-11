using NUnit.Framework;

namespace Sorting.Tests
{
    [TestFixture]
    public class ComparerTypeFactoryTests
    {
        [TestCase(new[] { -4, 12, -1 }, new[] { 4, 1 }, ComparerType.SumInRows, ExpectedResult = 1)]
        [TestCase(new[] { -11, 3 }, new[] { 0, -12, 9 }, ComparerType.SumInRows, ExpectedResult = -1)]
        [TestCase(new[] { 3, 2 }, new[] { 5, -5, 5 }, ComparerType.SumInRows, ExpectedResult = 0)]
        [TestCase(new[] { -2, 6, 3 }, new[] { 4, -11 }, ComparerType.MaxInRows, ExpectedResult = 1)]
        [TestCase(new[] { 4, 3 }, new[] { -2, 11, 9 }, ComparerType.MaxInRows, ExpectedResult = -1)]
        [TestCase(new[] { 6, -5, 7 }, new[] { 7, 2 }, ComparerType.MaxInRows, ExpectedResult = 0)]
        [TestCase(new[] { 9, 8 }, new[] { 3, 1, 7 }, ComparerType.MinInRows, ExpectedResult = 1)]
        [TestCase(new[] { -11, 3 }, new[] { 0, 11, 9 }, ComparerType.MinInRows, ExpectedResult = -1)]
        [TestCase(new[] { -2, -5 }, new[] { 1, -10, 2 }, ComparerType.MinInRows, ExpectedResult = 0)]
        public int Compare_ArraysWithComparisonCriteria_ComparisonResult(int[] firstArray, int[] secondArray, ComparerType comparerType)
        {
            return comparerType.Compare(firstArray, secondArray);
        }
    }
}

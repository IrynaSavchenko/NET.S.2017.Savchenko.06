using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class SumInRowsDescendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return rhs.Sum().CompareTo(lhs.Sum());
        }
    }
}

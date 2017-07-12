using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class SumInRowsAscendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return lhs.Sum().CompareTo(rhs.Sum());
        }
    }
}

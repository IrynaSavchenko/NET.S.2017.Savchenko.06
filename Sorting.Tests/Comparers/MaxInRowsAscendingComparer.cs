using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class MaxInRowsAscendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return lhs.Max().CompareTo(rhs.Max());
        }
    }
}

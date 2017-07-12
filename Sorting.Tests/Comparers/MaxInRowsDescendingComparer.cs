using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class MaxInRowsDescendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return rhs.Max().CompareTo(lhs.Max());
        }
    }
}

using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class MinInRowsAscendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return lhs.Min().CompareTo(rhs.Min());
        }
    }
}

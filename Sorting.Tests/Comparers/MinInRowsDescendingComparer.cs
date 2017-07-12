using System.Linq;

namespace Sorting.Tests.Comparers
{
    public class MinInRowsDescendingComparer : IComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            return rhs.Min().CompareTo(lhs.Min());
        }
    }
}

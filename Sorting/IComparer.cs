namespace Sorting
{
    /// <summary>
    /// Interface for array comparers
    /// </summary>
    public interface IComparer
    {
        int Compare(int[] lhs, int[] rhs);
    }
}

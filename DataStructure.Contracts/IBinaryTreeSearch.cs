namespace DataStructure.Contracts
{
    public interface IBinaryTreeSearch<T> : IMyCollection  where T : IComparable<T>
    {
        void Add(T value);
        bool Contains(T value);
        T[] ToArray();
    }
}

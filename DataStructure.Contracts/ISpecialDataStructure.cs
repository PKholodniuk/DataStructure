namespace DataStructure.Contracts
{
    public interface ISpecialDataStructure<T> : IMyCollection
    {
        bool Contains(T value);
        T[] ToArray();
    }
}

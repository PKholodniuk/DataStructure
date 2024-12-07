using System.Collections.Generic;
namespace DataStructure.Contracts
{
    public interface IMyList<T> : IMyCollection
    {
        void Add(T value);
        bool Contains(T value);
        T[] ToArray();
    }
}

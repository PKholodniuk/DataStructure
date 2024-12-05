using System;
namespace DataStructure.Contracts
{
    public interface IMyList : IMyCollection
    {
        void Add(object value);
        bool Contains(object value);
        object[] ToArray();
    }
}

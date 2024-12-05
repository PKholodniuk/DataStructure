namespace DataStructure.Contracts
{
    public interface ISpecialDataStructure : IMyCollection
    {
        bool Contains(object value);
        object[] ToArray();
    }
}

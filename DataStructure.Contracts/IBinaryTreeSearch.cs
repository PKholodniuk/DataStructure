namespace DataStructure.Contracts
{
    public interface IBinaryTreeSearch : IMyCollection
    {
        void Add(int value);
        bool Contains(int value);
        int[] ToArray();
    }
}

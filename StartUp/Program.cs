namespace DataStracture
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<int> list = new List<int>();
            int capacity = list.Capacity;
            Console.WriteLine("Capacity: " + capacity);

            for (int i = 0; i < 100000; i++)
            {
                list.Add(i);
                if (list.Capacity > capacity)
                {
                    capacity = list.Capacity;
                    Console.WriteLine("Capacity: " + capacity);
                }
            }
            Console.ReadLine();
        }
    }
}
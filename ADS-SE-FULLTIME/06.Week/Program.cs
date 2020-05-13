using System;

namespace _06.Week
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine(list.IndexOf(2));
            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.Contains(5));
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Remove(2));
        }
    }
}

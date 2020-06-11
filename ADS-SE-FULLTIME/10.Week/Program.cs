using System;
using System.Collections.Generic;

namespace _10.Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };


            Graph graphInstance = new Graph(graph);
            graphInstance.Dijkstra(0);



            Dictionary<String, int> notes = new Dictionary<string, int>();
            notes["Ivan"] = 5;
            notes["Ivan"] = 6;
            notes["Dragan"] = 6;


            HashSet<int> set = new HashSet<int>();
            set.Add(5);

        }
    }
}

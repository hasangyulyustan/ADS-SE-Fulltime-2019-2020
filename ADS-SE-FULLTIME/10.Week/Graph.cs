using System;
using System.Collections.Generic;

namespace _10.Week
{
    public class Graph
    {
        private int[,] vertices;


        public Graph(int[,] vertices)
        {
            this.vertices = vertices;
        }

        public void AddEdge(int i, int j, int value)
        {
            vertices[i, j] = value;
        }

        public void RemvoeEdge(int i, int j)
        {
            AddEdge(i, j, 0);
        }

        public bool HasEdge(int i, int j)
        {
            return vertices[i, j] != 0;
        }

        public List<int> GetSuccessors(int i)
        {
            List<int> successors = new List<int>();

            for (int j = 0; j < vertices.GetLength(0); j++)
            {
                if (vertices[i, j] != 0)
                {
                    successors.Add(j);
                }
            }

            return successors;
        }

        public void TraverseBFS(int node)
        {
            bool[] visited = new bool[vertices.GetLength(0)];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write("{0} ", currentNode);

                List<int> successors = GetSuccessors(currentNode);

                foreach (int childNode in successors)
                {
                    if (!visited[childNode])
                    {
                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }


        private int MinDistance(int[] distances, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < distances.Length; i++)
            {
                if(!visited[i] && min >= distances[i])
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // Funtion that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation 
        public void Dijkstra(int src)
        {
            int size = vertices.GetLength(0);


            int[] dist = new int[size]; // The output array. dist[i] 
                                        // will hold the shortest 
                                        // distance from src to i 

            // visited[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] visited = new bool[size];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < size; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < size - 1; count++)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int currentNode = MinDistance(dist, visited);

                // Mark the picked vertex as processed 
                visited[currentNode] = true;

                // Update dist value of the adjacent 
                // vertices of the picked vertex. 
                for (int v = 0; v < size; v++)

                    // Update dist[v] only if is not in 
                    // visited, there is an edge from u 
                    // to v, and total weight of path 
                    // from src to v through u is smaller 
                    // than current value of dist[v] 
                    if (!visited[v] && vertices[currentNode, v] != 0 && dist[currentNode] != int.MaxValue && dist[currentNode] + vertices[currentNode, v] < dist[v])
                    {
                        dist[v] = dist[currentNode] + vertices[currentNode, v];
                    }
            }

            // print the constructed distance array 
            PrintDijkstraSolution(dist);
        }


        // A utility function to print 
        // the constructed distance array 
        void PrintDijkstraSolution(int[] dist)
        {
            Console.Write("Vertex \t\t Distance "
                          + "from Source\n");
            for (int i = 0; i < vertices.GetLength(0); i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GraphArray
{
    class Graph
    {
        //Количество вершин в графе
        public int number { get; set; }

        public static int[,] newGraph(int number)
        {
            int n = number;
            int[,] graph = new int[n, n];
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Random rand = new Random();
                    graph[i, j] = rand.Next(1,10);
                    graph[j, i] = graph[i, j];
                }
            }
            graph[2, 5] = 100_000;
            graph[5, 2] = 100_000;
            graph[3, 6] = 100_000;
            graph[6, 3] = 100_000;
            graph[1, 4] = 100_000;
            graph[4, 1] = 100_000;
            return graph;
        }

        public static void Deykstra(int[,] graph) //Алгорим Дейкстры
        {
            int number = 7;
            int startNode = 6;
            int[] dist = new int[number];
            Queue<int> node = new Queue<int>(); //Сохраняем номера вершин в очередь
            node.Enqueue(startNode);
            for (int i = 0; i < number; i++)
            {
                dist[i] = 100_000;
            }
            dist[startNode] = 0;
            while (node.Count != 0)
            {
                int i = node.Dequeue();
                for (int j = 0; j < number; j++)
                {
                    if (graph[i, j] + dist[i] < dist[j] )
                    {
                       dist[j] = graph[i, j] + dist[i];
                       node.Enqueue(j);
                    }
                }
            }
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(dist[i]);
            }
        }
    }
}

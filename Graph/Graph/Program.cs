using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node.AddNode(node, 2, 10);
            node.AddNode(node, 3, 10);
            node.AddNode(node, 4, 10);
            Node node2 = node.Edges[0].nextNode;
            node.AddNode(node2, 5, 20);
            node.AddNode(node2, 6, 20);
            Node node3 = node2.Edges[1].nextNode;
            node.AddNode(node3, 7, 30);
            node.AddNode(node3, 8, 30);
            node.AddNode(node3, 9, 30);
            Node node4 = node.Edges[2].nextNode;
            node.AddNode(node4, 10, 40);
            node.AddNode(node4, 11, 40);
            node3.AddNodeToNode(node3, node, 50);
            node.PrintBFS(node); //Обходим в ширину и выводим на экран
            Console.ReadLine();
        }
    }
}




using System;
using System.Collections.Generic;

namespace Graph
{
    class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(int _value) 
        {
            Value = _value;
        }

        public void AddNode(Node firstNode, int valueNewNode, int weightNewNode)
        {
            Node secondNode = new Node(valueNewNode);
            Edge newEdge = new Edge(secondNode, weightNewNode);
            firstNode.Edges.Add(newEdge);
        }

        public void Print()
        {
           
        }


    }
    class Edge //Ребро
    {
        public int Weight { get; set; }
        public Node Node { get; set; }

        public Edge(Node _node, int _Weight)
        {
            Node = _node;
            Weight = _Weight;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node startNode = new Node(1);
            startNode.AddNode(startNode, 2, 10);
            startNode.AddNode(startNode, 3, 10);
            startNode.AddNode(startNode, 4, 10);
            Node node2 = startNode.Edges[0].Node;
            node2.AddNode(node2, 5, 20);
            node2.AddNode(node2, 6, 20);
            Node node3 = node2.Edges[1].Node;
            node3.AddNode(node3, 7, 30);
            node3.AddNode(node3, 8, 30);
            node3.AddNode(node3, 9, 30);
            Node node4 = startNode.Edges[2].Node;
            node4.AddNode(node4, 10, 40);
            node4.AddNode(node4, 11, 40);

        }
    }
}

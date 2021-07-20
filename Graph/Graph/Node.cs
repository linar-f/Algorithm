using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //

        public Node()
        {

        }

        public Node(int _value)
        {
            Value = _value;
            Edges = new List<Edge>();
        }

        public void AddNode(Node firstNode, int valueNewNode, int weightEdge)
        {
            Node secondNode = new Node(valueNewNode);
            secondNode.AddNodeToNode(firstNode, secondNode, weightEdge);
        }

        public void AddNodeToNode(Node firstNode, Node secondNode, int weightEdge)
        {
            Edge newEdge = new Edge(secondNode, weightEdge);
            if (firstNode.Edges == null)
            {
                firstNode.Edges.Add(newEdge);
                //List<Edge> Edges = new List<Edge>() { newEdge };
            }
            else
            {
                firstNode.Edges.Add(newEdge);
            }
        }

        public void PrintBFS(Node node) //Обход в ширину
        {
            Queue<Node> bufer = new Queue<Node>(); //Используем очередь
            bufer.Enqueue(node);
            List<int> passed = new List<int>();
            bool skip = false;
            while (bufer.Count != 0)
            {
                Node element = bufer.Dequeue();
                skip = false;
                foreach (var pass in passed)
                {
                    if (element.Value == pass)
                    {
                        skip = true;
                    }
                }
                if (skip != true)
                {
                    Console.WriteLine($"{element.Value}");
                    for (int i = 0; i < element.Edges.Count; i++)
                    {
                        passed.Add(element.Value);
                        bufer.Enqueue(element.Edges[i].nextNode);
                    }
                }
            }
        }
    }
}

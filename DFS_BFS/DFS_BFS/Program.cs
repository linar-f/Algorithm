using System;
using System.Collections.Generic;

namespace DFS_BFS
{
    class Program
    {
        public class Node //
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public Node Parent { get; set; }
        }

        class Tree //
        {
            Node node = new Node() { Value = 1 };

            public Node BFS(int value)
            {
                var node1 = node;
                Queue<Node> bufer = new Queue<Node>();
                bufer.Enqueue(node1);
                Console.WriteLine($"Очередь");
                bool stop = false;
                while (stop != true)
                {
                    Node element = bufer.Dequeue();
                    Console.WriteLine($"{element.Value}");
                    if (element.Value == value)
                    {
                        node1 = element;
                        stop = true;
                    }
                    else
                    {
                        if (element.LeftChild != null)
                        {
                            bufer.Enqueue(element.LeftChild);
                        }
                        if (element.RightChild != null)
                        {
                            bufer.Enqueue(element.RightChild);
                        }
                    }
                }
                return (node1);
            }

            public Node DFS(int value)
            {
                var node1 = node;
                var stack = new Stack<Node>();
                stack.Push(node1);
                Console.WriteLine($"Стэк");
                bool stop = false;
                while (stop != true)
                {
                    Node element = stack.Pop();
                    Console.WriteLine($"{element.Value}");
                    if (element.Value == value)
                    {
                        node1 = element;
                        stop = true;
                    }
                    else
                    {
                        if (element.RightChild != null)
                        {
                            stack.Push(element.RightChild);
                        }
                        if (element.LeftChild != null)
                        {
                            stack.Push(element.LeftChild);
                        }
                    }
                }

                return (node1);
            }

            public void AddItem(int value)
            {
                var node1 = node;
                Queue<Node> bufer = new Queue<Node>();
                bufer.Enqueue(node1);
                bool stop = false;
                while (stop != true)
                {
                    var element = bufer.Dequeue();
                    if (element.LeftChild != null)
                    {
                        bufer.Enqueue(element.LeftChild);
                    }
                    if (element.RightChild != null)
                    {
                        bufer.Enqueue(element.RightChild);
                    }
                    if (element.LeftChild == null)
                    {
                        node1 = element;
                        Node newNode = new Node { Value = value };
                        node1.LeftChild = newNode;
                        node1.LeftChild.Parent = node1;
                        stop = true;
                    }
                    else if (element.RightChild == null)
                    {
                        node1 = element;
                        Node newNode = new Node { Value = value };
                        node1.RightChild = newNode;
                        node1.RightChild.Parent = node1;
                        stop = true;
                    }
                }
            }

            public void PreOrderTravers(Node root)
            {
                if (root != null)
                {
                    Console.Write($"{root.Value}");
                    if (root.LeftChild != null || root.RightChild != null)
                    {
                        Console.Write('(');
                        if (root.LeftChild != null)
                        {
                            PreOrderTravers(root.LeftChild);
                        }
                        else
                        {
                            Console.Write("null");
                        }
                        Console.Write(',');

                        if (root.RightChild != null)
                        {
                            PreOrderTravers(root.RightChild);
                        }
                        else
                        {
                            Console.Write("null");
                        }
                        Console.Write(')');
                    }
                }
            }

            public void PrintTree()
            {
                PreOrderTravers(node);
            }

            public void RemoveItem(int value)
            {
                Node node1 = BFS(value);
                if (node1.Parent != null)
                {
                    if (node1.Parent.LeftChild.Value == value)
                    {
                        node1.Parent.LeftChild = null;
                    }
                    if (node1.Parent.RightChild.Value == value)
                    {
                        node1.Parent.RightChild = null;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Tree tree = new Tree(); // При объявлении дерева, вершина создается сразу со значением 1
            tree.AddItem(2); //
            tree.AddItem(3);
            tree.AddItem(4);
            tree.AddItem(5);
            tree.AddItem(6);
            tree.AddItem(7);
            tree.AddItem(8);
            tree.AddItem(9);
            tree.AddItem(10);
            tree.PrintTree();
            Console.WriteLine();
            tree.BFS(10);
            Console.WriteLine();
            tree.DFS(7);
            //tree.RemoveItem(5);
            Console.ReadLine();
        }
    }
}

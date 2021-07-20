using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Edge //Ребро
    {
        public int Weight { get; set; }
        public Node nextNode { get; set; }

        public Edge(Node _node, int _Weight)
        {
            nextNode = _node;
            Weight = _Weight;
        }
    }
}

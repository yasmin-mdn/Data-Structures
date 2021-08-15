using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Priority_Queue;

namespace C11
{
    class Graph
    {
        private long nodeCount;
        private List<Tuple<Node,long>>[] edges;
        public Graph(long nc)
        {
            nodeCount = nc;
            edges = new List<Tuple<Node, long>>[(int)nc];
            for (int i = 0; i < nc; i++)
                edges[i] = new List<Tuple<Node, long>>();
        }
        public void AddEdge(long start,long end,long weight)
        {
            edges[start].Add(Tuple.Create(new  Node(end,0),weight));
        }
        public long UCS(long start,long goal)
        {
            SimplePriorityQueue<Node,Node> fringe=new SimplePriorityQueue<Node,Node>();

            while(fringe.Count!=0){
                if()
            }
        }
        public string PathUCS(long start, long goal)
        {
            //Your code
            throw new NotImplementedException();
        }
    }
}

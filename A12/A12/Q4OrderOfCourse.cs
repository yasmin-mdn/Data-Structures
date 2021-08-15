using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse : Processor
    {
        List<long>[] graph;
        bool[] visited;
        List<long> post;
        long clock=0;
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);

        public long[] Solve(long nodeCount, long[][] edges)
        {
            graph = convertToDirectedGraph(nodeCount, edges);
            var tmp=topologicalsort(graph, nodeCount);
            return tmp;
        }

        private long[] topologicalsort(List<long>[] graph, long nodeCount)
        {
            post=new List<long>();
            DFS(graph, nodeCount);
            post.Reverse();
            return post.ToArray();

        }
        private void DFS(List<long>[] graph, long nodeCount)
        {

            visited = new bool[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                if (!visited[i])
                {
                    Explore(graph, i + 1);

                }

            }
            
        }
        private void Explore(List<long>[] graph, long v)
        {
                visited[v-1]=true;
                
                foreach(var t in graph[v-1]){
                    if(visited[t-1]==false ){
                      Explore(graph,t);

                    }
                }
                post.Add(v);
            }

        private List<long>[] convertToDirectedGraph(long nodeCount, long[][] edges)
        {
            List<long>[] graph = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                graph[i] = new List<long>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0] - 1].Add(edge[1]);
            }
            return graph;
        }
        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}

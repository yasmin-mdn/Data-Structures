using System;
using System.Collections.Generic;
using TestCommon;
namespace A12
{
    
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) {//this.ExcludeTestCaseRangeInclusive(3,100);this.ExcludeTestCases(1);
         }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            List<long>[] graph=convertToGraph(nodeCount,edges);
            int res=BFS(graph,StartNode,EndNode,nodeCount);
           return res;
        }

        private int BFS(List<long>[] graph, long startNode, long endNode,long nodeCount)
        {   
            bool[] visited=new bool[nodeCount];
            Queue<long> queue=new Queue<long>();
            queue.Enqueue(startNode);
            
            while(queue.Count!=0){
                var q=queue.Dequeue();
                if(q==endNode){
                    return 1;
                }
                visited[q-1]=true;
                foreach(var t in graph[q-1]){
                    if(!visited[t-1]){
                        queue.Enqueue(t);
                    }
                    
                }
            }
            return 0;
        }

        private List<long>[] convertToGraph(long nodeCount, long[][] edges)
        {
            List<long>[] graph=new List<long>[nodeCount];
            for(int i=0;i<nodeCount;i++){
                graph[i]=new List<long>();
            }
            foreach(var edge in edges){
                graph[edge[0]-1].Add(edge[1]);
                graph[edge[1]-1].Add(edge[0]);
            }
            return graph;
        }

        
    }
}

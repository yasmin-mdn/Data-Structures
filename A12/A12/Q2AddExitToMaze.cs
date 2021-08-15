using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
         bool[] visited;
          int[] ccnum;
          int cc;
        public Q2AddExitToMaze(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            List<long>[] graph=convertToGraph(nodeCount,edges);
            int res=DFS(graph,nodeCount);
           return res;
        }

        private int DFS(List<long>[] graph, long nodeCount)
        {
            cc=1;
            visited=new bool[nodeCount];
            ccnum=new int[nodeCount];
            for(int i=0;i<nodeCount;i++){
                if(!visited[i]){
                    Explore(graph,i+1);
                    cc++;
                }
               
            }
            return cc-1;
        }

        private void Explore(List<long>[] graph, long v)
        {
            Stack<long> mystack=new Stack<long>();
            mystack.Push(v-1);
            while(mystack.Count!=0){
                var p=mystack.Pop();
                visited[p]=true;
                ccnum[p]=cc;
                foreach(var t in graph[p]){
                    if(visited[t-1]==false ){
                        mystack.Push(t-1);
                        
                    }
                }
                
            }

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

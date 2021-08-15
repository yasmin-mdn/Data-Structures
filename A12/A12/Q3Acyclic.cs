using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        List<long>[] graph;
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
             graph=convertToDirectedGraph(nodeCount,edges);
             return isCyclic(nodeCount);
        }
         private List<long>[] convertToDirectedGraph(long nodeCount, long[][] edges)
        {
            List<long>[] graph=new List<long>[nodeCount];
            for(int i=0;i<nodeCount;i++){
                graph[i]=new List<long>();
            }
            foreach(var edge in edges){
                graph[edge[0]-1].Add(edge[1]-1);
            }
            return graph;
        }

        private bool isCyclicUtil(int i, bool[] visited,  
                                    bool[] recStack)  
    {  
          
         
        if (recStack[i])  
            return true;  
  
        if (visited[i])  
            return false;  
              
        visited[i] = true;  
  
        recStack[i] = true;  
        List<long> children = graph[i];  
          
        foreach (int c in children)  
            if (isCyclicUtil(c, visited, recStack))  
                return true;  
                  
        recStack[i] = false;  
  
        return false;  
    } 
     private long isCyclic(long nodeCount)  
    {  
        bool[] visited = new bool[nodeCount];  
        bool[] recStack = new bool[nodeCount];  
        
        for (int i = 0; i < nodeCount; i++)  
            if (isCyclicUtil(i, visited, recStack))  
                return 1;  
        return 0;  
    }  
    }
}
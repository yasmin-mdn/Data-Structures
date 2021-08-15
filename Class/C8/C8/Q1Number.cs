using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C8
{
    public class Q1Number : Processor
    {
        public Q1Number(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            DisjointSets disjoint=new DisjointSets((int)nodeCount);
            foreach(var e in edges){
                long start=e[0]-1;
                long end =e[1]-1;
                disjoint.union((int)start,(int)end);

            }
            HashSet<long> hash=new HashSet<long>();
            for(int i=0;i<nodeCount;i++){
                long f=disjoint.find(i);
                hash.Add(f);
            }
            return hash.Count();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q2Stones : Processor
    {
        public Q2Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {int day=0;
        int i=0;
        long sum=0;
            if(stones.Sum()<n){
                return 0;
            }
            while(sum<n){
                sum+=stones[i];
                day++;
                i++;   
            }
                
           return day;
        }
    }
}

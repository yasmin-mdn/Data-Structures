using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q1LinearSearch : Processor
    {
        public Q1LinearSearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            for(int t=0;t<a[0];t++){
                if(a[1]==numbers[t])
                return t;
            }
            return -1;
        }
    }
}

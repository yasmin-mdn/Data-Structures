using System;
using TestCommon;

namespace C7
{
    public class Q2HungryFrogPath : Processor
    {
        public Q2HungryFrogPath(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long[]>)Solve);


        public static long[] Solve(long n, long p, long[][] numbers)
        {
            return new long[n];
        }
    }
}

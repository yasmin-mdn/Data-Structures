using System;
using TestCommon;

namespace C3
{
    public class Q1MaximumPerimeterTriangle : Processor
    {
        public Q1MaximumPerimeterTriangle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Solve(long len,long[] edges)
        {
            return edges;
        }
    }
}

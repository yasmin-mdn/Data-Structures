using System;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q2Tetris : Processor
    {
        public Q2Tetris(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] arr)
        {
            var max = arr.Max();
            int i = 0;
            var count = 0;
            while(arr[i] != max)
            {
                i++;
            }
            return 0;
            
        }
    }
}

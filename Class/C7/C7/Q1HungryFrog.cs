using System;
using TestCommon;

namespace C7
{
    public class Q1HungryFrog : Processor
    {
        public Q1HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[,] res = new long[2, n];
            res[0, 0] = numbers[0][0];
            res[1, 0] = numbers[1][0];

            for (long j = 1; j < n; j++)
            {

                res[0, j] = Math.Max(res[0, j - 1], res[1, j - 1] - p) + numbers[0][j];
                res[1, j] = Math.Max(res[1, j - 1], res[0,j - 1] - p) + numbers[1][j];

               
            }
             return Math.Max(res[0,n-1],res[1,n-1]);
        }
    }
}

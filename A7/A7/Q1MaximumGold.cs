using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            int i;
            int j;
            long[,] arr = new long[goldBars.Length+1, W + 1];
            for (i = 0; i <= goldBars.Length; i++)
            {
                for (j = 0; j <= W; j++)
                {
                    if (i == 0 || j == 0)
                        arr[i, j] = 0;

                    else if (goldBars[i-1] <= j)
                        arr[i, j] = Math.Max(goldBars[i-1] + arr[i - 1, j - goldBars[i-1]],
                            arr[i - 1, j]);
                    else
                        arr[i, j] = arr[i - 1, j];
                }
            }

            return arr[goldBars.Length, W];
           
        }
    }
}

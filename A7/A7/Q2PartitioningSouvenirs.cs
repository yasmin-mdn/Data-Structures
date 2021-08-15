using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) {
           
         }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            var sum1 = souvenirs.Sum();
            var n = sum1 / 3;
            if (sum1 % 3 != 0 || souvenirsCount==0)
            {
                return 0;
            }


            bool[,] dp = new bool[sum1+1, sum1+1];
            dp[0, 0] = true;
            for (long i = 0; i < souvenirsCount; i++)
            {
                for (long j = sum1; j >= 0; --j)
                {
                    for (long k = sum1; k >= 0; --k)
                    {
                        if (dp[j, k])
                        {
                            dp[j + souvenirs[i],k] = true;
                            dp[j,k + souvenirs[i]] = true;
                        }
                    }
                }
            }
            if(dp[sum1 / 3,sum1 / 3])
            return 1;
            return 0 ;
        }

    }
}

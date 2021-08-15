using System;
using System.Linq;
using System.Threading;
using TestCommon;

namespace C4
{
    public class Q1CupCake : Processor
    {
        public Q1CupCake(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public static long Solve(long[] init,long[] prices)
        {
            var n = init[0];
            var k = init[1];
            var minidx = 0;
            for(int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < prices[minidx])
                {
                    minidx = i;

                }
            }
            if (k <= 1)
            {
                return prices.Max();

            }
            if (k == 2)
            {
                if (minidx == prices.Length - 1 || minidx == 0)
                {
                    return prices.Min();
                }
                else
                {
                    if (prices[0] > prices[prices.Length - 1])
                    {
                        return prices[prices.Length - 1];
                    }
                    else { return prices[0]; }
                }
                
            }
            if (k >= 3)
            {
                return prices.Min();
            }
            return -1;
        }
       
    }
}

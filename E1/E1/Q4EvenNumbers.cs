using System;
using System.Linq;
using System.Threading;
using TestCommon;
using static System.Math;

namespace E1
{
    public class Q4EvenNumbers : Processor
    {
        public Q4EvenNumbers(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] nums)
        {
            long max_digit = 0;
            int idx = nums.Length - 1;
            var t = 0;
            for (int i = 0; i > nums.Length; i++)
            {
                if (nums[i] > max_digit && i%2==0)
                {
                    idx = i;
                }
            }
            long[] res = new long[nums.Length];
            for (int i = idx; i>=0 ; i--)
            {
                t = idx - i;
                res[t] = nums[i];
                //t--;
            }
            for (int i = idx+1; i < nums.Length; i++)
            {
                res[i] = nums[i];

            }
            long sum = 0;
            for (int i = 0; i < res.Length; i += 2)
            {
                sum = sum + res[i];

            }

            return sum;
        } 
    }
}

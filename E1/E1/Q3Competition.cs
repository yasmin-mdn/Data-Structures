using System;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q3Competition : Processor
    {
        public Q3Competition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] powers)
        {
            return findMaximum(powers, 0,(long) Math.Pow(2,n)-1);

        }

        static long findMaximum(long[] powers, long left,long right)
        {
            if (right-left==1)
            {
                return powers[right] + powers[left];
            }
            var mid =(left+right)/2;
            long max1 = 0;
            long max2 = 0;
            for (long i = left; i <= mid; i++)
            {
                if (max1 < powers[i])
                {
                    max1 = powers[i];
                }
            }
            for (long i = mid+1; i <= right; i++)
            {
                if (max2 < powers[i])
                {
                    max2 = powers[i];
                }
            }
            var maxleft = findMaximum(powers, left, mid);
            var maxright= findMaximum(powers, mid+1, right);

            return Math.Max(maxleft+max2,maxright+max1);




        }

    }

       
       
    }


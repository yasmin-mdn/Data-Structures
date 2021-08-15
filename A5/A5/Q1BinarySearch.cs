using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            for(int i=0;i<b.Length;i++)
            {
                b[i]= BinarySearch(a, b[i]);
            }
            return b;
        }
        private static long BinarySearch( long[] numbers, long k )
        {
            long left = 0;
            long right = numbers.Length - 1;
            long mid = 0;
            while (left <=right) {
                var t = (right - left) / 2;
                mid = left + t;
                if (k==numbers[mid])
                {
                    return mid;
                }
                if (k > numbers[mid])
                {
                    left = mid + 1;
                }
                    
                else if (k < numbers[mid])
                {
                    right = mid - 1;
                }
                    
            
            }
            return -1;
        }
          
    }
}

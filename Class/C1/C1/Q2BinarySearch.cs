using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q2BinarySearch : Processor
    {
        public Q2BinarySearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            return BinarySearch(a, numbers, 0, (int)a[0]);
        }

        private static long BinarySearch(long[] a, long[] numbers, int left, int right)
        {
           if(right<left){
               return -1;
           }
           var mid = (left + right)/2;
            if(a[1]>numbers[mid])
                return   BinarySearch(a,numbers,mid+1,right);
            else if(a[1]<numbers[mid])
                return    BinarySearch(a,numbers,left,mid-1);
            else return mid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            randomizQuiksort(ref a, 0, a.Length - 1);
            return a; 
        }

        public static (int,int) partishen3(ref long [] a,int l,int r)
        {
            var x = a[l];
            int start = l + 1, end = l;
            for(int i = l + 1; i < r + 1; i++)
            {
                if (a[i] <= x)
                {
                    end += 1;
                    //(a[i], a[end]) = (a[end], a[i]);
                    swap(ref a[i], ref a[end]);
                    if (a[end] < x)
                    {
                        //(a[start], a[end]) = (a[end], a[start]);
                        swap(ref a[start],ref a[end]);
                        start += 1;
                    }
                    
                }
            }
            // (a[l], a[start - 1]) = (a[start - 1], a[l]);
            swap(ref a[start-1], ref a[l]);
            return (start,end);
        }

        public static void randomizQuiksort(ref long[] a, int l, int r)
        {
            int m1=0, m2=0;
            if (l > r)
            {
                return;
               // new long[0];
            }
                
            var rnd = new Random();
            var k = rnd.Next(l, r);
            // (a[l], a[k]) = (a[k], a[l]);
            swap(ref a[l], ref a[k]);
            (m1, m2) = partishen3( ref a, l, r);
            randomizQuiksort(ref a, l, m1 - 1);
            randomizQuiksort(ref a, m2 + 1, r);

            //return a;

        }
        public static void swap(ref long a, ref long b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}

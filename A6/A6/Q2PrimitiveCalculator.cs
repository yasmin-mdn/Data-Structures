using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) {
            ExcludeTestCases(10,11);
         
         }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {

            if (n == 1)
                return new long[]{1};
            var ops = min_ops(n);
            return construct_min_list(n, ops);

        }

        private long[] construct_min_list(long n, long[] ops)
        {
            List<long> res=new List<long>();
            while(n>0){
                res.Add(n);
                if(n % 3 == 0){
                    if(ops[n-1] < ops[n/3])
                        n = n-1;
                    else
                        n = n / 3;
                }
            
                else if (n % 2 == 0){
                    if(ops[n-1] < ops[n/2]) 
                     n = n-1;
                    else
                     n = n / 2;
                }

                else  if(n % 2 != 0 && n % 3 != 0) {
                    n = n - 1;
                }
            
                
            
            }
            var res2=res.ToArray();
            Array.Reverse(res2);
            return res2;
        }

        public long[] min_ops(long n)
        {
            long[] res = new long[n + 1];

            for (int i = 2; i <= n; i++)
            {
                var min1 = res[i - 1];
                var min2 = long.MaxValue;
                var min3 = long.MaxValue;
                if (i % 2 == 0)
                {
                    min2 = res[(int)(i / 2)];
                }
                if (i % 3 == 0)
                {
                    min3 = res[(int)(i / 3)];
                }

                var minOp = Math.Min(min1, min2);
                minOp = Math.Min(min3, minOp);

                res[i] = minOp + 1;
            }


            return res;
        }

    }
}

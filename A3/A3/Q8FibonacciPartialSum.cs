using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long m, long n)
        {
            if(m>n){
                (m,n)=(n,m);
            }
           var t1=(n+2)%60;
           var t2=(m+1)%60;
            var fibonachiSum1=(fib(t1)-1);
            var fibonachiSum2=(fib(t2)-1);
            var res=fibonachiSum1-fibonachiSum2;
            if((res)%10<0)
                return 10+res;
            return res ;
        }
         public long fib(long n)
        {   switch(n){
            case 0:
                return 0;
            case 1:
                return 1;
        }
           int[] fib=new int[n+1];
            fib[0]=0;
            fib[1]=1;
            for(int i=2;i<=n;i++){
                fib[i]=(fib[i-1]%10+fib[i-2]%10)%10;
            }
            return fib[fib.Length-1];
            }
    }
}

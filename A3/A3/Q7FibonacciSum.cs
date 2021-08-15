using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            var t=(n+2)%60;
            var fibonachiSum=(fib(t)-1);
            if(fibonachiSum%10<0)
                return 10+fibonachiSum;
            return fibonachiSum ;
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

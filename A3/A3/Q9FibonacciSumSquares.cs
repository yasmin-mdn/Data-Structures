using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            var t1=(n)%60;
            var t2=(n-1)%60;
            var fibonachi1=fib(t1);
            var fibonachi2=fib(t2);
            var res=(fibonachi1 *(fibonachi2+fibonachi1) )%10;
            if(res<0)
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
            return fib[fib.Length-1] ;
        }
    }
}

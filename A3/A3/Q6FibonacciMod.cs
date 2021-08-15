using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            var pi = pisano(b);
            a = a % pi;
            long prev = 0;
            long curr = 1;
            if (a == 0)
            {
                return 0;
            }

            else if (a == 1)
            {
                return 1;
            }
            for (int i = 0; i < a - 1; i++)
            {
                long temp = 0;
                temp = curr;
                curr = (prev + curr) % b;
                prev = temp;
            }

            return curr % b;


        }

        private long pisano(long m)
        {
            long perevious, current;
            long res = 0;
            perevious = 0;
            current = 1;
            for (int i = 0; i < m * m; i++)
            {
                (perevious, current) = (current, (perevious + current) % m);
                if (perevious == 0 && current == 1)
                {
                    res = i + 1;
                }

            }
            return res;
        }

        public long fib(long n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
            }
            long[] fib = new long[n + 1];
            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fib[i] = (fib[i - 1] + fib[i - 2]);
            }
            return fib[fib.Length - 1];
        }
    }
}

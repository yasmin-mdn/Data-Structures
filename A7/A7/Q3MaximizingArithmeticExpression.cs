using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {   long min_value=long.MinValue;
            long max_value=long.MaxValue;
            expression.ToCharArray();
            var n = (expression.Length - 1) / 2;
            long[] digits = new long[n + 1];
            char[] ops = new char[n];
            int t=0;
            int u=0;
            for (int i = 0; i < expression.Length; i=i+2)
            {
                digits[t] = Convert.ToInt64(expression[i]-'0');
                t++;
            }
            for (int i = 1; i < expression.Length; i+=2)
            {
                ops[u] = expression[i];
                u++;
            }

            long[,] dp_max = new long[n + 1, n + 1];
            long[,] dp_min = new long[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp_max[i, i] = digits[i];
                dp_min[i, i] = digits[i];
            }

             for(int s=0;s<digits.Length;s++){
                 for(int i=0;i<digits.Length-s-1;i++){
                    var j = i + s+1;
                    (min_value, max_value)= min_max_value(dp_max,dp_min,ops,i, j);
                    dp_max[i,j] = max_value;
                    dp_min[i,j] = min_value;
                 }
             } 
        
            
            
            return dp_max[0,digits.Length-1];

        }


        private (long,long) min_max_value(long[,] dp_max, long[,] dp_min, char[] ops, int i, int j)
        {   var min_value=long.MaxValue;
            var max_value = long.MinValue;
            for (int k = i; k < j; k++)
            {
                var a = eval(dp_max[i, k], dp_max[k + 1, j], ops[k]);
                var b = eval(dp_max[i, k], dp_min[k + 1, j], ops[k]);
                var c = eval(dp_min[i, k], dp_max[k + 1, j], ops[k]);
                var d = eval(dp_min[i, k], dp_min[k + 1, j], ops[k]);
                max_value = max4(max_value, a, b, c, d);
                min_value = min4(min_value, a, b, c, d);
            }

            return (min_value,max_value);
        }

        private long min4(long min_value, long a, long b, long c, long d)
        {
            var t1 = Math.Min(a, b);
            var t2 = Math.Min(c, d);
            var t3 = Math.Min(t1, t2);
            return Math.Min(min_value, t3);
        }

        private long max4(long max_value, long a, long b, long c, long d)
        {
            var t1 = Math.Max(a, b);
            var t2 = Math.Max(c, d);
            var t3 = Math.Max(t1, t2);
            return Math.Max(max_value, t3);
        }

        private long eval(long a, long b, char op)
        {

            if (op == '+')
                return a + b;
            else if (op == '-')
                return a - b;
            else if (op == '*')
                return a * b;
            return 1;
        }
    }
}

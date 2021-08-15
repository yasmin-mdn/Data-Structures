using System;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q1Matrix : Processor
    {
        public Q1Matrix(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[,]>)Solve);

        public static long[,] Solve(long n, long[] rows,long[] columns)
        {
            long[,] res = new long[n, n];


            for(int i = 0; i < n; i++)
            {

                long max = rows.Max();
                var r = Array.IndexOf(rows, max);
                while (rows[r] != 0)
                {
                    for (int c = 0; c < columns.Length; c++)
                    {
                        if (columns[c] == 0)
                        {
                            res[r, c] = 0;
                            continue;

                        }
                        else
                        {
                            if (rows[r] == 0) break;
                            res[r, c] = 1;
                            rows[r] = rows[r] - 1;
                            columns[c] = columns[c] - 1;
                        }
                    }

                }
            }

            return res;
        }
    }
}

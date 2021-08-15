using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace C6
{
    public class Q1Game : Processor
    {
        public Q1Game(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public static long Solve(long n, long m, long[][] prizes)
        {
            long[][] res = new long[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new long[m];
            }
            for (long i = m - 2; i >= -1; i--)
            {
                if (prizes[n - 1][i] != 0)
                {
                    res[n - 1][i] = res[n - 1][i + 1] + prizes[n - 1][i];
                }
            }
            for (long i = n - 3; i > -1; i -= 2)
            {
                long c = ((n - 1) - i) / 2;
                c--;
                for (long j = m - 1; j >= -1; j--)
                {
                    if (prizes[i][j] != 0)
                        res[i][j] = 0;
                    else
                    {
                        long m1 = 0;
                        long m2 = 0;
                        if (j + 1 != m)
                        {
                            m2 = res[i][j + 1];
                        }
                        if (c % 2 == 0)
                        {
                            if (j + 1 != m)
                            {
                                m1 = res[i + 2][j + 1];
                            }
                        }
                        else
                        {
                            if (j != 0)
                            {
                                m1 = res[i + 2][j - 1];
                            }
                        }


                        if (m1 != 0 || m2 != 0)
                        {
                            res[i][j] = prizes[i][j] + Math.Max(m1, m2);
                        }
                        else
                        {
                            res[i][j] = 0;
                        }

                    }
                }
            }

            return res[0][m - 1];
        }
    }
}

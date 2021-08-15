using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree : Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            var m1 = seq1.Length + 1;
            var m2 = seq2.Length + 1;
            var m3 = seq3.Length + 1;
            int[,,] arr = new int[m1, m2, m3];
            for (int i = 1; i < m1; i++)
            {
                for (int j = 1; j < m2; j++)
                {
                    for (int k = 1; k < m3; k++)
                    {
                        if (seq1[i - 1] == seq2[j - 1] && seq2[j - 1] == seq3[k - 1])
                        {
                            arr[i, j, k] = arr[i - 1, j - 1, k - 1] + 1;
                        }
                        else
                            arr[i, j, k] = Max3(arr[i - 1, j, k], arr[i, j - 1, k], arr[i, j, k - 1]);
                    }
                }
            }





            return arr[m1-1, m2-1, m3-1];
        }
        private int Max3(int v1, int v2, int v3)
        {
            var t = Math.Max(v1, v2);
            return Math.Max(v3, t);
        }
    }
}

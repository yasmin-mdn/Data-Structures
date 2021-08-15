using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            int[,] array = new int[seq1.Length + 1, seq2.Length + 1];
             for (int i = 0; i <= seq1.Length; i++)
            {
                for (int j = 0; j <= seq2.Length; j++)
                {
                    if (i == 0)

                        array[i, j] = i;

                    else if (j == 0)
                        array[i, j] = j;


                    else if (seq1[i - 1] == seq2[j - 1])
                        array[i, j] = array[i - 1, j - 1]+1;

                    else
                        array[i, j] = Math.Max(array[i-1,j],array[i,j-1]); 
                                        
                }
            }
           return array[seq1.Length,seq2.Length];
        }

        
    }
}

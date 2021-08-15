using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {

            int[,] array = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0)

                        array[i, j] = j;

                    else if (j == 0)
                        array[i, j] = i;


                    else if (str1[i - 1] == str2[j - 1])
                        array[i, j] = array[i - 1, j - 1];

                    else
                        array[i, j] = 1 + min3(array[i, j - 1], // Insert 
                                           array[i - 1, j], // Remove 
                                           array[i - 1, j - 1]); // Replace 
                }
            }

            return array[str1.Length, str2.Length];
        }



        private int min3(int v1, int v2, int v3)
        {
            var t = Math.Min(v1, v2);
            return Math.Min(v3, t);
        }
    }
}

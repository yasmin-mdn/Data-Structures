using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
           
            int[,] array = new int[COINS.Length, n + 1];
            for (int i = 0; i < COINS.Length; i++)
            {
                array[i, 0] = 0;
            }
            for (int i = 0; i < n + 1; i++)
            {
                array[0, i] = i;
            }
            for (int i = 1; i < COINS.Length; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (COINS[i]>j)
                    {
                        array[i, j] = array[i - 1, j];
                    }
                    else
                    {
                        array[i, j] = Math.Min(array[i - 1, j], array[i, j - COINS[i]]+1);
                    }
                }
            }
            return array[COINS.Length - 1, n];
        }

    }
}


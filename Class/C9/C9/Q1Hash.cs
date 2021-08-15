using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C9
{
    public class Q1Hash : Processor
    {
        public Q1Hash(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string s1, string s2)
        {
            long count = 0;
            if (s2.Length < s1.Length)
            {
                var t = s1;
                s1 = s2;
                s2 = t;
            }
            
            for (int i = 1; i <= s1.Length; i++)
            {
                if ((s1.Length % i == 0) && (s2.Length % i == 0))
                {   bool flag = false;
                    string d = s1.Substring(0, i);
                    for (int j = i; j < s1.Length; j += i)
                    {
                        string sub1 = s1.Substring(j, i);
                        if (sub1.GetHashCode() != d.GetHashCode())
                        {
                            flag = true;
                            break;
                        }
                    }

                    for (int j = 0; j < s2.Length; j += i)
                    {
                        string sub2 = s2.Substring(j, i);
                        if (sub2.GetHashCode() != d.GetHashCode())
                        {
                            flag = true;
                            break;
                        }
                    }
                        if (!flag)
                        {
                            count++;
                        }
                    }
                }
            return count;
        }
    }
}

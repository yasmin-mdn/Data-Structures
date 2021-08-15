using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C2
{
    public class Q1PrimeNumbers : Processor
    {
        public Q1PrimeNumbers(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string>)Solve);

        public static string Solve(string a)
        {var st = "";
            var number = int.Parse(a);
            var tmp = 0;
            while (number % 2 == 0)
            {
                tmp += 1;
                number = number / 2;
            }
            if(tmp==1){
                    st+="2*";
                }
            if(tmp!=0&&tmp!=1){st+=$"2^{tmp}*";}
            tmp = 0;
            for (int i = 3; i <= number; i += 2)
            {
                while (number % i == 0)
                {
                    tmp++;
                    number /= i;
                }
                if(tmp==1){
                    st+=$"{i}*";
                }
                else if(tmp==0){continue;}
                else{
                    st+=$"{i}^{tmp}*";
                }
                tmp=0;
            }


            
           st=st.Substring(0,st.Length-1);
            return st;
        }

    }
}

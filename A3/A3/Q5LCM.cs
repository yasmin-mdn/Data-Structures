﻿using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            return a*b/GCD(a,b);
        }
        public long GCD(long a,long b){
            if(a==1 || b==1){
                return 1;
            }
            if(a<b){
                (a,b)=(b,a);
            }
            if(b==0){
                return a;
            }
            var r=a%b;
            return GCD(b,r);
        }

    }
}

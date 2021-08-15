﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public  virtual long Solve(long[] numbers)
        {
            return FastMethod(numbers);
        }
        public static long FastMethod(long[] numbers){
            if(numbers.Length<2){
                return 0;
            }
            int index1=0;
            int index2=1;
            if(numbers[index1]<numbers[index2]){
                index1=1;
                index2=0;
            }
            for(int i =2;i<numbers.Length;i++){
                if(numbers[i]>=numbers[index1]){
                    index2=index1;
                    index1=i;
                }
                else if(numbers[i]>numbers[index2]&&numbers[i]<numbers[index1]&& i!=index1){
                    index2=i;
                }
            }
            //  for(int i =1;i<numbers.Length;i++){
            //     if(numbers[i]>=numbers[index2]&&numbers[i]!=numbers[index1]){
            //         index2=i;
            //     }
            //}
            return numbers[index1]*numbers[index2];
        } 
    }
    
}

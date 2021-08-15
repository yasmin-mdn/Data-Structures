using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            var sw = new Stopwatch();
            sw.Start();
            var rand = new Random();
            //bool t=true;
            while(sw.ElapsedMilliseconds<5000){
                long num = rand.Next(1000); 
                long[] arr=new long[num];
                for(int i=0;i<num;i++){
                    arr[i]=rand.Next();
                }
                Assert.AreEqual(Q1NaiveMaxPairWise.SlowMethod(arr),Q2FastMaxPairWise.FastMethod(arr));
            }
            sw.Stop();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}
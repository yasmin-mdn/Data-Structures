using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {


        public Q1CheckBrackets(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            Stack<char> mystack = new Stack<char>();
            int idx = 0;
            int a = 0;
            bool balanced = true;
            while (idx < str.Length)
            {
                if (mystack.Count == 0)
                {
                    a = idx;
                }
                if (str[idx] == '(' || str[idx] == '{' || str[idx] == '[')
                {
                    mystack.Push(str[idx]);

                }
                else
                {
                    if (str[idx] == ')' || str[idx] == '}' || str[idx] == ']')
                    {
                        if (mystack.Count == 0)
                        {
                            balanced = false;
                            break;
                        }
                        else
                        {
                            var top = mystack.Pop();
                            if ((top == '[' && str[idx] != ']') || (top == '{' && str[idx] != '}') || (top == '(' && str[idx] != ')'))
                            {
                                balanced = false;
                                break;
                            }
                        }
                    }
                }
                idx++;
            }
            if (balanced && mystack.Count == 0)
                return -1;
            else
            {
                if ((idx >= str.Length) && mystack.Count!=0)
                   return a + 1 ;
                else
                    return idx + 1 ;
            }
           
        }

    }
}
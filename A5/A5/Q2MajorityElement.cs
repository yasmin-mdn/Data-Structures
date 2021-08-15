using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement : Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            Array.Sort(a);
            int i = 1, count = 1;
            while (i < n)
            {
                while (i < n && a[i] == a[i - 1] )
        {
                    i = i + 1;
                    count = count + 1;
        }
                if (count > n / 2)
                    return 1;
                count = 1;
                i = i + 1;
    }

            return 0;

        }



            //        // if the maxCount is greater than size/2, 
            //        // return the corresponding element.

            //            cout << "Majority element is " << arr[index] << endl;

            //        else
            //            cout << "Majority Element does not exist" << endl;
            //    }
            //}

            //  public static (long[], long[]) count_merge(long[][] left_half, long[][] right_half)
            //    {
            //        long[] left_majors, right_minors, left_minors, right_majors = new long[0];
            //        (left_majors, right_minors) = chunk_process(left_half[0], right_half[1]);
            //        (right_majors, left_minors) = chunk_process(right_half[0], left_half[1]);
            //        if (left_majors[0] == right_majors[0])
            //        {
            //            return (left_majors + right_majors, left_minors + right_minors);
            //        }

            //        else if (left_majors.Length > right_majors.Length)
            //        {
            //            return (left_majors, right_majors + left_minors + right_minors);

            //        }

            //        else
            //            return (right_majors, left_majors + right_minors + left_minors);
            //    }


            //    public static (long[],long[]) chunk_process(long[]majors,long[] eles)
            //    {
            //       var left = new long[0];
            //        foreach(var ele in eles)
            //        {
            //            if (majors[0] == ele)
            //                majors.Append(ele);
            //            else

            //                left.Append(ele);
            //        }

            //        return (majors, left);

            //    }
            //    var mid = left + ((right - left) / 2);
            //    var left_half = get_majority_element(a, left, mid);
            //    var right_half = get_majority_element(a, mid, right);
            //            return count_merge(left_half, right_half);

            //        int left = 0, right = a.Length - 1;
            //            if (left == right)
            //            {
            //                return new long[] { -1 };
            //}

            //if (left + 1 == right)
            //{
            //    return new long[][] { { a[left] }, { } };
        }
    }

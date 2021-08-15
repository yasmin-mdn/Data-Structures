using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize,
            long[] arrivalTimes,
            long[] processingTimes)
        {
            List<(long, long)> requests = new List<(long, long)>();
            for (long i = 0; i < arrivalTimes.Length; i++)
                requests.Add((arrivalTimes[i], processingTimes[i]));
            buffer buffer = new buffer(bufferSize);
            List<long> responses = new List<long>();
            foreach ((long, long) request in requests)
                responses.Add(buffer.response(request));
            return responses.ToArray();
        }
    }
    public class buffer
    {
        public long Size;
        public List<long> finishingTimes;
         public long response((long, long) request)
        {
            long startTime;
            while ((finishingTimes.Count > 0) && (finishingTimes[0] <= request.Item1))
                finishingTimes.RemoveAt(0);
            if (finishingTimes.Count < Size)
            {
                if (finishingTimes.Count == 0)
                {
                    finishingTimes.Add(request.Item1 + request.Item2);
                    return request.Item1;
                }
                else
                {
                    startTime = finishingTimes.Last();
                    finishingTimes.Add(startTime + request.Item2);
                    return startTime;
                }
            }
            else
                return -1;
        }
        public buffer(long size)
        {
            Size = size;
            finishingTimes = new List<long>();
        }


       

    }




}
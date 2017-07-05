using System;

namespace ProtoScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSize = 28;
            var temp = new Candidate[maxSize];
            var temp2 = new CandidateStat[maxSize];
            for (int i = 0; i != maxSize; i++)
            {
                temp[i] = new Candidate("E" + (i + 1), null);
                temp2[i] = new CandidateStat("E" + (i + 1), 0, 0, null);
            }
            var scheduleBody = new CandidateQueue(temp2, 92);
            DateTime start = new DateTime(2017,6,1);
            DateTime end = new DateTime(2017,8,31);

            TimeSpan diff = end - start;
            for (DateTime i = start;i<=end;i=i.AddDays(1))
            {
                scheduleBody.PickNext(i);
            }
            scheduleBody.Display(start, end);
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProtoScheduler
{
    class CandidateQueue
    {
        private CandidateStat[] _queue;
        private IList<string> _output;

        public void Display(DateTime start, DateTime end)
        {
            foreach(string s in _output)
            {
                Console.WriteLine("{0} is for {1}", start.ToString(), s);
                start.AddDays(1);
            }
            foreach(CandidateStat cst in _queue)
            {
                cst.Display();
            }
        }
        public CandidateQueue(CandidateStat[] cqueue, int size)
        {
            _queue = cqueue;
            _output = new List<string>(size);
        }
        public void PickNext(DateTime current)
        {
            bool isWeekend = false;
            var candiry = from cst in _queue
                          where cst._lastOnCall == null || (long)(current - cst._lastOnCall.Value).TotalDays > 5
                          select cst;
            int tmpmin = candiry.Min(x => x.Weight());
            candiry = from cst in candiry
                      where cst.Weight() == tmpmin
                      select cst;
            if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
            {
                int tempmin = candiry.Min(x=> x._weekEndCnt);
                isWeekend = true;
                candiry = from cst in candiry
                          where cst._weekEndCnt == tempmin
                          select cst;
            }
            else
            {
                int tempmin = candiry.Min(x => x._weekDayCnt);
                candiry = from cst in candiry
                          where cst._weekDayCnt == tempmin
                          select cst;
            }
            var result = (from cst in candiry
                          where !cst._excludeDates.Contains(current)
                          select cst.Name).ToArray();
            int len = result.Length;
            Random rand1 = new Random();
            int offset = rand1.Next(len);
            foreach (CandidateStat cst in _queue)
            {
                if (cst.Name == result[offset])
                {
                    if (isWeekend)
                    {
                        cst._weekEndCnt++;
                    }
                    else
                    {
                        cst._weekDayCnt++;
                    }
                }
            }
            _output.Add(result[offset]);
        }
    }
}

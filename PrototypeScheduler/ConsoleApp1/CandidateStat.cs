using System;
using System.Collections.Generic;

namespace ProtoScheduler
{
    class CandidateStat
    {
        public int _weekDayCnt;
        public int _weekEndCnt;
        public DateTime? _lastOnCall;
        public DateTime[] _excludeDates=new DateTime[0];
        private string _name;
        public CandidateStat(string name,int weekday,int weekend,DateTime? lastcall)
        {
            _name = name;
            _weekDayCnt = weekday;
            _weekEndCnt = weekend;
            _lastOnCall = lastcall;
        }
        public int Weight()
        {
            return _weekDayCnt + _weekEndCnt;
        }
        public string Name
        {
            get{
                return _name;
            }
        }
        public void Display()
        {
            Console.WriteLine("{0} weekday:{1} weekend:{2}", _name, _weekDayCnt, _weekEndCnt);
        }
    }
}

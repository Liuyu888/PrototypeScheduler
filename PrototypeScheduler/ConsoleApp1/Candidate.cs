using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoScheduler
{
    class Candidate
    {
        private readonly string _name;

        private readonly DateTime? _startDate;

        internal Candidate(string name, DateTime? startDate)
        {
            _name = name;
            _startDate = startDate;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
        }


    }
}

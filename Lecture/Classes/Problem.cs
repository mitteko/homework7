using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    internal class Problem
    {
        public int problemNum { get; set; }
        public string description { get; set; }

        public Problem(int problemNum, string description)
        {
            problemNum = problemNum;
            description = description;
        }
    }
}

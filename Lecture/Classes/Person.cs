using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    internal class Person
    {
        public string name { get; set; }
        public string passportNum { get; set; }
        public Problem problem { get; set; }
        public Temperament temper { get; set; }

        public Person(string name, string passportNumber, Problem problem, Temperament temper)
        {
            name = name;
            passportNum = passportNumber;
            problem = problem;
            temper = temper;
        }
    }
}

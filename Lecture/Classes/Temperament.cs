using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    internal class Temperament
    {
        public int scandalousness { get; set; } // степень скандальности от 0 до 10 (10-скандалист, 0-паинька)
        public int intelligence { get; set; } //ум (1-умный, 0-тупой)

        public Temperament(int scandalousness, int intelligence)
        {
            scandalousness = scandalousness;
            intelligence = intelligence;
        }
    }
}

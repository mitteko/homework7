using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    internal class WindowSelector
    {
        public static int SelectWindow(Person person)
        {
            // норм житель выбирает окно в зависимости от проблемы
            return person.problem.problemNum - 1; // проблема 1 идет в окно 0, проблема 2 в окно 1, иначе в третье окно
        }
    }
}

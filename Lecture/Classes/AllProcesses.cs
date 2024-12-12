using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    internal class AllProcesses
    {
        static Queue<Person> people = new Queue<Person>();

        public static void InputPerson()
        {
            Console.WriteLine("Введите имя жителя (или 'стоп' для завершения и перехода к обработке):");
            string name = Console.ReadLine();

            if (name.ToLower() == "стоп")
                return; 

            Console.WriteLine("Введите номер паспорта:");
            string passportNumber = Console.ReadLine();

            Console.WriteLine("Введите номер проблемы (1 - нет отопления, 2 - ошибка в оплате, 3 - вода из батареи):");
            int problemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите описание проблемы:");
            string problemDescription = Console.ReadLine();

            Console.WriteLine("Введите уровень скандальности (0-10):");
            int scandalLevel = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите уровень интеллекта (0 - тупой, 1 - умный):");
            int intelligenceLevel = int.Parse(Console.ReadLine());

            //создаем нового жителя и добавляем в очередь
            Person person = new Person(name, passportNumber, new Problem(problemNumber, problemDescription), new Temperament(scandalLevel, intelligenceLevel));
            people.Enqueue(person);

            //рекурсивный вызов для ввода следующего жителя
            InputPerson();

            //после ввода всех жителей, начинаем их обработку
            ProcessNextPerson();
        }

        static void ProcessNextPerson()
        {
            if (people.Count == 0)
                return; 

            var resident = people.Dequeue(); // получаем следующего жителя
            int windowIndex = WindowSelector.SelectWindow(resident);

            // обработка скандалистов
            if (resident.temper.scandalousness >= 5)
            {
                Console.WriteLine($"{resident.name} - на сколько человек он обгонит?");
                if (int.TryParse(Console.ReadLine(), out int skipCount) && skipCount > 0)
                {
                    Console.WriteLine($"{resident.name} обошел {skipCount} человек.");
                }
            }

            // выбор окна
            if (windowIndex >= 0 && windowIndex < 3) // 3 окна
            {
                Console.WriteLine($"{resident.name} направляется к: окно {windowIndex + 1}");
            }
            else
            {
                Console.WriteLine($"{resident.name} не попал в ни одно окно.");
            }

            Console.WriteLine();

            ProcessNextPerson();
        }
    }
}

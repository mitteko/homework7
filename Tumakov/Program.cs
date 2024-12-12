using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Console.ReadKey();
        }


        /// Упражнение 8.2 
        /// Реализовать метод, который в качестве входного параметра принимает
        /// строку string, возвращает строку типа string, буквы в которой идут в обратном порядке. Протестировать метод.
        static void Task1()
        {
            Console.WriteLine("Упражнение 8.2:");
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            string reversed = ReversedString(input);

            Console.WriteLine($"Строка '{input}' преобразована в '{reversed}'");
        }
        
        //метод для разворачивания строки
        static string ReversedString(string str)
        {
            char[] charsInput = str.ToCharArray();
            Array.Reverse(charsInput);
            return new string(charsInput);
        }


        /// Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. 
        /// Если такого файла не существует, то программа выдает пользователю сообщение и заканчивает работу, 
        /// иначе в выходной файл записывается содержимое исходного файла, но заглавными буквами.
        static void Task2()
        {
            Console.WriteLine("Упражнение 8.3:");
            Console.Write("Введите имя файла: ");
            string inputFile = Console.ReadLine();

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Такого файла не сущетсвует!!!");
                return; 
            }

            string outputFile = Path.ChangeExtension(inputFile, ".out"); // - выходной файл

            try
            {
                string message = File.ReadAllText(inputFile);
                string upperMessage = message.ToUpper();

                File.WriteAllText(outputFile, upperMessage);
                Console.WriteLine($"Содержимое было успешно записано в файл: {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }


        /// Упражнение 8.4 
        /// Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable. 
        /// Использовать оператор is и as. (Интерфейс IFormattable обеспечивает функциональные возможности форматирования значения объекта в строковое представление.)
        static void Task3()
        {
            Console.WriteLine("Упражнение 8.4:");
            Console.Write("Введите ЧИСЛО: ");
            int number = int.Parse(Console.ReadLine());
            DateTime dateTime = DateTime.Now;
            Console.Write("Введите СТРОКУ: ");
            string text = Console.ReadLine();

            CheckIFormattable(number);
            CheckIFormattable(dateTime);
            CheckIFormattable(text);
        }

        static void CheckIFormattable(object obj)
        {
            //если obj является экземпляром интерфейса IFormattable, производится явное преобразование этого объекта к типу IFormattable
            if (obj is IFormattable formattable)
            {
                Console.WriteLine($"Объект {obj} реализует интерфейс IFormattable");
            }
            else
            {
                Console.WriteLine($"Объект {obj} не реализует интерфейс IFormattable");
            }
        }
    }
}

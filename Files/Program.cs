using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            List<Songs> songs = new List<Songs>()
            {
                new Songs("On My Own","Darci"),
                new Songs("Do I Wanna Know?","Arctic Monkeys"),
                new Songs("Brave","Riley Pearce"),
                new Songs("Я по уши в тебя влюблён","MyaGi"),
            };
            Task2(songs);
        }

        /*Домашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
адрес. Разделителем между ФИО и адресом электронной почты является символ #:
Иванов Иван Иванович # iviviv@mail.ru
Петров Петр Петрович # petr@mail.ru
Сформировать новый файл, содержащий список адресов электронной почты.
Предусмотреть метод, выделяющий из строки адрес почты. Методу в
качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
public void SearchMail (ref string s). */

        static void Task1()
        {
            Console.WriteLine("Упражнение 8.1");
            string[] startFile = File.ReadAllLines("TxtFiles\\students.txt");

            List<string> emails = new List<string>();
            foreach (string line in startFile)
            {
                string email = SplitTheString(line);
                if (!string.IsNullOrEmpty(email))
                {
                    emails.Add(email);
                }
            }

            File.WriteAllLines("TxtFiles\\emails.txt", emails);
        }

        //метод для разбивания строки и возвращения email
        public static string SplitTheString(string s)
        {
            string[] parts = s.Split('#');

            if ( parts.Length > 1 )
            {
                return parts[1].Trim();
            }
            else
            {
                return string.Empty;
            }
        }


        /*Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. В
цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
песню в списке. Песня представляет собой класс с методами для заполнения каждого из
полей, методом вывода данных о песне на печать, методом, который сравнивает между
собой два объекта:
class Song{
string name; //название песни
string author; //автор песни
Song prev; //связь с предыдущей песней в списке
//метод для заполнения поля name
//метод для заполнения поля author
//метод для заполнения поля prev
//метод для печати названия песни и ее исполнителя
public string Title(){... /*возвращ название+исполнитель*/
        //метод, который сравнивает между собой два объекта-песни:
        //public bool override Equals(object d) { ...} */

        static void Task2(List<Songs> list)
        {
            Console.WriteLine("Домашнее задание 8.2");
            
            foreach (var song in list)
            {
                Console.WriteLine(song.Title());
            }
            for (int i = 1; i < list.Count; i++)
            {
                list[i].GivePrev(list[i - 1]);
            }
            if (list[0].Equals(list[1]))
            {
                Console.WriteLine("это одна и та же песня");
            }
            else
            {
                Console.WriteLine("это разные песни");
            }
        }
    }
}

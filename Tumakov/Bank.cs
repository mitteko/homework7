using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    public enum accountType
    {
        cберегательный,
        текущий
    }
    
    /// <summary>
    /// НОВЫЙ МЕТОД В САМОМ НИЗУ
    /// </summary>
    
    internal class Bank
    {

        private uint id;
        private double balance;
        private accountType isaccType;
        private static uint idgen = 0;


        public Bank() { }

        public Bank(uint id, double balance, accountType isaccType)
        {
            this.id = id;
            this.balance = balance;
            this.isaccType = isaccType;
        }

        //конструктор для генерируемого ID
        public Bank(double balance, accountType isaccType)
        {
            this.id = IdForGen();
            this.balance = balance;
            this.isaccType = isaccType;
        }

        //новое значение ID
        public void Information(uint isid)
        {
            this.id = isid;

        }

        public void VvodInformation(double balance, accountType istype)
        {
            this.balance = balance;
        }

        public void InformationForGen(uint isid)
        {
            this.id = IdForGen();

        }

        private uint IdForGen()
        {
            idgen++;
            return idgen;
        }

        public void Input(double summa)
        {
            if (summa < balance)
            {
                this.balance -= summa;
                Console.WriteLine("Деньги успешно сняты!");
            }
            else
            {
                Console.WriteLine("На счете недостаточно средств");
            }
        }

        public void Output(double summa)
        {
            this.balance += summa;
            Console.WriteLine("Счет успешно пополнен!");
        }
        
        public void Print()
        {
            Console.WriteLine($"Номер счета: {id}\nБаланс: {balance}\nТип банковского счета: {isaccType}");
        }


        /// <summary>
        /// 8.1 - НОВЫЙ МЕТОД.
        /// В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой.
        /// У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        /// </summary>

        public void Transfer(Bank targetAcc, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной");
                return;
            }

            if (amount > this.balance)
            {
                Console.WriteLine("Недостаточно средств для перевода");
                return;
            }

            this.Input(amount); //снимаем деньги с текущего счёта
            targetAcc.Output(amount); //переводим средства на целевой счёт
            Console.WriteLine($"Переведено {amount} на счёт {targetAcc.id}");
        }
    }

}

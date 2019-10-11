using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvent
{
    public delegate void Print(int value);
    class Program
    {
        static void Main(string[] args)
        {
            var mailHelper = new MailHelper();
            var queueHelper = new QueueHelper();
            var logHelper = new LogHelper();

            var printHelper = new PrintHelper();

            printHelper.AfterPrinted += mailHelper.HandleAfterPrinted;
            printHelper.AfterPrinted += queueHelper.HandleAfterPrinted;
            printHelper.AfterPrinted += logHelper.HandleAfterPrinted;

            printHelper.PrintNumber(12312);
           
            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }

        public static void TakeAPrinter(Print print)
        {
            var abc = 123123;
            Console.WriteLine("Taking a printer");
            print(abc);
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }
    }

}

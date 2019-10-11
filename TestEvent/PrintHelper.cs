using System;

namespace TestEvent
{
    public class AfterPrintEventArgs: EventArgs
    {
        public string Name { get; set; }
    }
    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint BeforePrintEvent;

        public event EventHandler<AfterPrintEventArgs> AfterPrinted;

        public PrintHelper()
        {

        }

        public void PrintNumber(int num)
        {
            //call delegate method before going to print
            BeforePrintEvent?.Invoke();

            Console.WriteLine("Number: {0,-12:N0}", num);

            AfterPrinted?.Invoke(this, new AfterPrintEventArgs { Name = "haha after print"});
        }

        public void PrintDecimal(int dec)
        {
            BeforePrintEvent?.Invoke();

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney(int money)
        {
            BeforePrintEvent?.Invoke();

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature(int num)
        {
            BeforePrintEvent?.Invoke();

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            BeforePrintEvent?.Invoke();

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
}

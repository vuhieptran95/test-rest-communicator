namespace TestEvent
{
    public class MailHelper : IHandlePrinting
    {
        public void HandleAfterPrinted(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Mail handle after printing " + e.Name);
        }

        public void HandleBeforePrint(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Mail handle before printing " + e.Name);
        }
    }

    public class LogHelper: IHandlePrinting
    {
        public void HandleAfterPrinted(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Log handle after printing " + e.Name);
        }

        public void HandleBeforePrint(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Log handle before printing " + e.Name);
        }
    }

    public class QueueHelper : IHandlePrinting
    {
        public void HandleAfterPrinted(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Queue handle after printing " + e.Name);
        }

        public void HandleBeforePrint(object sender, AfterPrintEventArgs e)
        {
            System.Console.WriteLine("Queue handle before printing " + e.Name);
        }
    }
}

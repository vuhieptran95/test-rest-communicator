namespace TestEvent
{
    public interface IHandlePrinting
    {
        void HandleAfterPrinted(object sender, AfterPrintEventArgs e);

        void HandleBeforePrint(object sender, AfterPrintEventArgs e);
    }
}
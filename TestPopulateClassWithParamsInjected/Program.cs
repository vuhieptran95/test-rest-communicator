using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPopulateClassWithParamsInjected
{
    public interface IController
    {
        void Execute(MyContext context);
    }
    public class MyController : IController
    {
        public void Execute(MyContext context)
        {
            Console.WriteLine("Context name: "+ context.Name);
        }
    }
    public class MyContext
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var controller = new MyController();
            controller.Execute(new MyContext { Name = "asdfsf" });
        }
    }
}

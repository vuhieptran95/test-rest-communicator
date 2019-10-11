using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class A
    {
        public virtual void Do()
        {
            Console.WriteLine("A: Do");
        }
    }

    public class AChild : A
    {
        public override void Do()
        {
            //base.Do();
            Console.WriteLine("AChild: Do");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            A a = new AChild();
            a.Do();
            Console.ReadKey();

        }
    }
}

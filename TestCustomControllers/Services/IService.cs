using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCustomControllers.Services
{
    public interface IService
    {
        string DoSomething();
    }

    public class Service: IService
    {
        public string DoSomething()
        {
            return "Doing something";
        }

    }
}
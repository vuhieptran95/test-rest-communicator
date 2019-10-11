using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using TestCustomControllers.Services;

namespace TestCustomControllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            ViewBag.Text = _service.DoSomething();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class CustomControllerFactory : IControllerFactory
    {
        private readonly string _controllerNamespace = "TestCustomControllers.Controllers";

        //public CustomControllerFactory(string controllerNamespace)
        //{
        //    _controllerNamespace = controllerNamespace;
        //}
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var service = new Service();
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
            IController controller = Activator.CreateInstance(controllerType, new[] { service }) as Controller;
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
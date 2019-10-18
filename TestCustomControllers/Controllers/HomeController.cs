using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCustomControllers.Services;

namespace TestCustomControllers.Controllers
{
    public class MyModel
    {
        public string FromForm { get; set; }
    }

    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = new MyModel { FromForm = "12121212" };
            return model;
        }
    }

    public class HomeController : Controller
    {
        private readonly IService _service;
        public HomeController()
        {
            //ActionInvoker = new MyCustomActionInvoker();
        }

        public HomeController(IService service)
        {
            _service = service;
        }
        public ActionResult Index(MyModel myModel)
        {
            var model = new MyModel();
            UpdateModel(model);
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

    public class Custom2ControllerFactory: DefaultControllerFactory
    {

    }

    public class MyCustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName == "Index")
            {
                controllerContext.HttpContext.Response.Write("Fuck yeah!!");
                return true;
            }
            return false;
        }
    }
}
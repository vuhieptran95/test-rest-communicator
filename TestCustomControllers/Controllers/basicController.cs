using System.Web.Mvc;
using System.Web.Routing;
using TestCustomControllers.Services;

namespace TestCustomControllers.Controllers
{
    public class basicController : IController
    {
        private readonly IService _service;
        public basicController()
        {

        }

        public basicController(IService service)
        {
            _service = service;
        }
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];
            requestContext.HttpContext.Response.Write(
            string.Format("Controller: {0}, Action: {1}", controller, action));
        }
    }
}
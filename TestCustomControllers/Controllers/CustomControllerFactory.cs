using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using TestCustomControllers.Services;

namespace TestCustomControllers.Controllers
{
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly string _controllerNamespace = "TestCustomControllers.Controllers";

        //public CustomControllerFactory(string controllerNamespace)
        //{
        //    _controllerNamespace = controllerNamespace;
        //}
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "basic":
                    targetType = typeof(basicController);
                    break;
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "base";
                    targetType = typeof(basicController);
                    break;
            }
            return targetType == null ? null :
            (IController)DependencyResolver.Current.GetService(targetType);
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
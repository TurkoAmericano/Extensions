using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NUnit.Framework;

namespace Extensions
{
    public static class ResultAssertions
    {

        public static void AssertRedirectToRouteResult(this ActionResult result,
                                                      string actionName,
                                                      string controllerName)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var routeResult = (RedirectToRouteResult)result;
            Assert.GreaterOrEqual(routeResult.RouteValues.Count, 2);

            Assert.AreEqual(actionName.ToLower(), routeResult.RouteValues["action"].ToString().ToLower());
            Assert.AreEqual(controllerName.ToLower(), routeResult.RouteValues["controller"].ToString().ToLower());

        }

        public static void AssertRedirectToRouteResult(this ActionResult result,
                                               string actionName)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var routeResult = (RedirectToRouteResult)result;
            Assert.GreaterOrEqual(routeResult.RouteValues.Count, 1);
            Assert.AreEqual(actionName.ToLower(), routeResult.RouteValues["action"].ToString().ToLower());
        }

        public static void AssertRedirectToRouteResultValues(this ActionResult result,
                                              object model)
        {
            var routeResult = (RedirectToRouteResult)result;
            var propertyInfos = model.GetType().GetProperties();
            foreach (var prop in propertyInfos)
            {
                Assert.AreEqual(prop.GetValue(model, null),
                    routeResult.RouteValues[prop.Name]);
            }
        }

        public static void AssertViewResult(this ActionResult result,
                                            Controller controller)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsEmpty(((ViewResult)result).ViewName);
         
        }

        public static void AssertViewResult(this ActionResult result,
                                         Controller controller,
                                         string viewname)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(viewname, ((ViewResult)result).ViewName);
         
        }
    }
}

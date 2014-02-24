using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Extensions
{
    public static class ActionResultExtensions
    {
        public static string GetErrorMessage(this ActionResult actionResult, int index)
        {
            return ((ViewResult)actionResult).ViewData.ModelState["login"].Errors[index].ErrorMessage;
        }

        public static bool IsValidModelState(this ActionResult actionResult)
        {
            return ((ViewResult)actionResult).ViewData.ModelState.IsValid;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SMS.Web.Controllers
{
    public enum AlertType { success, danger, warning, info }

    public class BaseController : Controller
    {
        // store breadcrumb history in temp data
        public void BreadCrumbs(params (string,string)[] values)
        {
            TempData["Crumbs"] = values;
        }

        // Store Alert in TempData Storage thus only accessible in next Request
        public void Alert(string message, AlertType type = AlertType.info)
        {
            TempData["Alert.Message"] = message;
            TempData["Alert.Type"] = type.ToString();
        }

    }

}

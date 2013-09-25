using System.Web.Mvc;

namespace iBill.Areas.Admin.Controllers {
  public class BaseController : Controller {

    public int CurrentUserID {
      get {
        int uid;
        int.TryParse(Cookies.Get("__ibill-admin", "uid").ToString(), out uid);

        return uid;
      }
    }

    protected void SetMessage(string message, string className) {
      TempData["Message"] = message;
      TempData["CSS"] = className;
    }

  }
}
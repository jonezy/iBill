using System;
using System.Linq;
using System.Web.Mvc;

using iBill.Areas.Admin.Models;
using iBill.Data;

namespace iBill.Areas.Admin.Controllers {
  public class SecurityController : Controller {

    public ActionResult Index() {
      iBillEntities ctx = ContextFactory.GetContextPerRequest();
      
      return View("login");
    }

    [HttpPost]
    public ActionResult Index(LoginViewModel model) {
      iBillEntities ctx = ContextFactory.GetContextPerRequest();
      Adminuser user = ctx.Adminusers.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

      if (user == null) {
        TempData["Message"] = "Could not find a user with that username/password combination";
        TempData["CSS"] = "alert-danger";

        return View("login");
      }

      if (model.RememberMe) {
        Cookies.Set("__ibill-admin", "uid", user.Id.ToString(), DateTime.Now.AddMonths(12));
      } else {
        Cookies.Set("__ibill-admin", "uid", user.Id.ToString(), null);
      }

      return RedirectToAction("index", "dashboard");
    }

  }
}

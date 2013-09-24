using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iBill.Areas.Admin.Controllers {
  public class SecurityController : Controller {
    //
    // GET: /Admin/Security/

    public ActionResult Login() {
      return View();
    }

  }
}

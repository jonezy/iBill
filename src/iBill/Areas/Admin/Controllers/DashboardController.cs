using System.Web.Mvc;

namespace iBill.Areas.Admin.Controllers {
  [RequiresAuthentication]
  public class DashboardController : BaseController {

    public ActionResult Index() {
      return View();
    }

  }
}

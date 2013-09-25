﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using iBill.Areas.Admin.Controllers;
using iBill.Data;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class RequiresAuthentication : ActionFilterAttribute {
  public bool IsAdmin { get; set; }
  public string AccessDeniedMessage { get; set; }

  private RouteValueDictionary LoginRouteDictionay {
    get {
      RouteValueDictionary homepageRouteDictionary = new RouteValueDictionary();
      homepageRouteDictionary.Add("action", "index");
      homepageRouteDictionary.Add("controller", "security");

      return homepageRouteDictionary;
    }
  }

  public override void OnActionExecuting(ActionExecutingContext filterContext) {
    BaseController controller = (BaseController)filterContext.Controller;
    iBillEntities ctx = ContextFactory.GetContextPerRequest();
    Adminuser user = ctx.Adminusers.FirstOrDefault(u => u.Id == controller.CurrentUserID);
    
    if (user == null) {
      filterContext.Controller.TempData["Message"] = !string.IsNullOrEmpty(AccessDeniedMessage) 
        ? AccessDeniedMessage
        : "You must be logged in to access this page";
      filterContext.Controller.TempData["CSS"] = "alert-info";

      filterContext.Result = new RedirectToRouteResult(LoginRouteDictionay);
    }

    base.OnActionExecuting(filterContext);
  }
}

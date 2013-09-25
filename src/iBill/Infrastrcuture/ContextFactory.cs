using System.Web;

using iBill.Data;


public class ContextFactory {

  private static readonly string contextKey = typeof(iBillEntities).FullName;

  public static iBillEntities GetContextPerRequest() {
    HttpContext httpContext = HttpContext.Current;
    if (httpContext == null) {
      return new iBillEntities();
    } else {
      iBillEntities context = httpContext.Items[contextKey] as iBillEntities;

      if (context == null) {
        context = new iBillEntities();
        httpContext.Items[contextKey] = context;
      }

      return context;
    }
  }

}

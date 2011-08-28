using System.Web;

namespace SquishIt.Contrib.Mvc.Helpers
{
    public interface IJavaScriptHelper
    {
        void Add(params string[] javaScriptFiles);
        IHtmlString Render(string renderTo);
    }
}

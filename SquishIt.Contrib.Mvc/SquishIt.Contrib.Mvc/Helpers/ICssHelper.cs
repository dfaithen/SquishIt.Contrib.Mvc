using System.Web;

namespace SquishIt.Contrib.Mvc.Helpers
{
    public interface ICssHelper
    {
        void Add(params string[] cssFiles);
        IHtmlString Render(string renderTo);
    }
}

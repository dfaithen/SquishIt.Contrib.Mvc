using System.Web;

namespace SquishIt.Contrib.Mvc.Helpers
{
    public interface IJavaScriptHelper
    {
        void Add(params string[] localPaths);
        void AddRemote(string localPath, string remotePath);
        IHtmlString Render(string renderTo);
    }
}

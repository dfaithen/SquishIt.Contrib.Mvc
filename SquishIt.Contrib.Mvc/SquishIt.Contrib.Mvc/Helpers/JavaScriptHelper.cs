using System.Collections.Generic;
using System.Linq;
using System.Web;
using SquishIt.Framework;

namespace SquishIt.Contrib.Mvc.Helpers
{
    internal class JavaScriptHelper : IJavaScriptHelper
    {
        private static Stack<string> files = new Stack<string>();

        public void Add(params string[] javaScriptFiles)
        {
            foreach (string file in javaScriptFiles.Reverse())
            {
                if (!files.Contains(file))
                {
                    files.Push(file);
                }
            }
        }

        public IHtmlString Render(string renderTo)
        {
            if (!files.Any())
            {
                return null;
            }

            var builder = Bundle.JavaScript().Add(files.Pop());

            while (files.Any())
            {
                builder = builder.Add(files.Pop());
            }

            return new HtmlString(builder.Render(renderTo));
        }
    }
}

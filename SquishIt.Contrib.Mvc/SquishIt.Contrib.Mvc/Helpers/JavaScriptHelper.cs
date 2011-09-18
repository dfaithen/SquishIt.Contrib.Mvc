using System.Collections.Generic;
using System.Linq;
using System.Web;
using SquishIt.Framework;

namespace SquishIt.Contrib.Mvc.Helpers
{
    internal class JavaScriptHelper : IJavaScriptHelper
    {
        private static Stack<File> files = new Stack<File>();

        public void Add(params string[] localPaths)
        {
            foreach (string localPath in localPaths.Reverse())
            {
                var file = new File()
                {
                    LocalPath = localPath,
                };

                if (!files.Contains(file))
                {
                    files.Push(file);
                }
            }
        }

        public void AddRemote(string localPath, string remotePath)
        {
            var file = new RemoteFile()
            {
                LocalPath = localPath,
                RemotePath = remotePath,
            };

            if (!files.Contains(file))
            {
                files.Push(file);
            }
        }

        public IHtmlString Render(string renderTo)
        {
            if (files.Count == 0)
            {
                return null;
            }

            var file = files.Pop();
            SquishIt.Framework.JavaScript.IJavaScriptBundleBuilder builder;
            if (file is RemoteFile)
            {
                var remoteFile = (RemoteFile)file;
                builder = Bundle.JavaScript().AddRemote(remoteFile.LocalPath, remoteFile.RemotePath);
            }
            else
            {
                builder = Bundle.JavaScript().Add(file.LocalPath);
            }
            while (files.Count > 0)
            {
                file = files.Pop();
                if (file is RemoteFile)
                {
                    var remoteFile = (RemoteFile)file;
                    builder = builder.AddRemote(remoteFile.LocalPath, remoteFile.RemotePath);
                }
                else
                {
                    builder = builder.Add(file.LocalPath);
                }
            }

            return new HtmlString(builder.Render(renderTo));
        }
    }
}

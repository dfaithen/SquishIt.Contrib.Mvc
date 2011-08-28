using System;
using System.Web.Mvc;
using System.Web.Routing;
using SquishIt.Contrib.Mvc.Helpers;

namespace SquishIt.Contrib.Mvc
{
    public class SquishItHelper
    {
        public ViewContext ViewContext { get; private set; }
        public IViewDataContainer ViewDataContainer { get; private set; }
        public RouteCollection RouteCollection { get; private set; }

        public ICssHelper Css { get; private set; }
        public IJavaScriptHelper JavaScript { get; private set; }

        public SquishItHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : this(viewContext, viewDataContainer, RouteTable.Routes)
        {
        }

        public SquishItHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
        {
            #region Validation
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }
            if (viewDataContainer == null)
            {
                throw new ArgumentNullException("viewDataContainer");
            }
            if (routeCollection == null)
            {
                throw new ArgumentNullException("routeCollection");
            }
            #endregion

            ViewContext = viewContext;
            ViewDataContainer = viewDataContainer;
            RouteCollection = routeCollection;

            Css = new CssHelper();
            JavaScript = new JavaScriptHelper();
        }
    }

    public class SquishItHelper<TModel> : SquishItHelper
    {
        public ViewDataDictionary<TModel> ViewData { get; private set; }

        public SquishItHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : this(viewContext, viewDataContainer, RouteTable.Routes)
        {
        }

        public SquishItHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
            : base(viewContext, viewDataContainer, routeCollection)
        {
            ViewData = new ViewDataDictionary<TModel>(viewDataContainer.ViewData);
        }
    }
}

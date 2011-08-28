using System.Web.Mvc;

namespace SquishIt.Contrib.Mvc
{
    public abstract class SquishItBasePage : WebViewPage
    {
        public SquishItHelper SquishIt { get; set; }

        protected SquishItBasePage()
        {
        }

        public override void InitHelpers()
        {
            SquishIt = new SquishItHelper(ViewContext, this);

            base.InitHelpers();
        }
    }

    public abstract class SquishItBasePage<TModel> : WebViewPage<TModel>
    {
        public SquishItHelper SquishIt { get; set; }

        protected SquishItBasePage()
        {
        }

        public override void InitHelpers()
        {
            SquishIt = new SquishItHelper<TModel>(ViewContext, this);

            base.InitHelpers();
        }
    }
}

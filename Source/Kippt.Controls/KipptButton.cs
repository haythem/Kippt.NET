using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kippt.Controls
{
    [ToolboxData("<{0}:KipptButton runat=server></{0}:KipptButton>")]
    public class KipptButton : WebControl
    {
        /// <summary>
        /// Script reference from <see cref="https://github.com/kippt/kippt-button"/>.
        /// </summary>
        private readonly string script = "<script>(function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=\"http://addons.kippt.com/widgets.js\";fjs.parentNode.insertBefore(js,fjs);}}(document,\"script\",\"kippt-wjs\"));</script>";

        private Uri url;
        /// <summary>
        /// URL to save.
        /// </summary>
        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }

        private string title;
        /// <summary>
        /// (Optional) Title for the page.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private Uri source;
        /// <summary>
        /// (Optional) Source, e.g. page domain.
        /// </summary>
        public Uri Source
        {
            get { return source; }
            set { source = value; }
        }

        private string via;
        /// <summary>
        /// (Optional) Source clip URI if you want to reference another clip inside Kippt (e.g. /api/clips/1337/).
        /// </summary>
        public string Via
        {
            get { return via; }
            set { via = value; }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(script);

            output.AddAttribute("href", "https://kippt.com/save");
            output.AddAttribute("class", "kippt-save-button");
            output.AddAttribute("data-url", Url.ToString());

            if (!string.IsNullOrEmpty(title))
            {
                output.AddAttribute("data-title", Url.ToString());
            }

            if (source != null)
            {
                output.AddAttribute("data-source", source.ToString());
            }

            if (!string.IsNullOrEmpty(via))
            {
                output.AddAttribute("data-via", via);
            }

            output.RenderBeginTag("a");
            output.RenderEndTag();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderContents(writer);
        }
    }
}
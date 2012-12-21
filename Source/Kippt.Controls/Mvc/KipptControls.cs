using System;
using System.Text;
using System.Web.Mvc;

namespace Kippt.Controls.Mvc
{
    public static class KipptControls
    {
        /// <summary>
        /// Script reference from <see cref="https://github.com/kippt/kippt-button"/>.
        /// </summary>
        private static readonly string script = "<script>(function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=\"http://addons.kippt.com/widgets.js\";fjs.parentNode.insertBefore(js,fjs);}}(document,\"script\",\"kippt-wjs\"));</script>";

        /// <summary>
        /// Renders the kippt button.
        /// </summary>
        /// 
        /// <param name="url">URL to save.</param>
        /// <param name="title">(Optional) Title for the page.</param>
        /// <param name="source">(Optional) Source, e.g. page domain.</param>
        /// <param name="via">(Optional) Source clip URI if you want to reference another clip inside Kippt (e.g. /api/clips/1337/).</param>
        /// <param name="inlineScript">Specify whether if the script is inline or not. If not the script is required using <see cref="KipptButtonScript"/> method.</param>
        public static MvcHtmlString KipptButton(this HtmlHelper helper, Uri url, string title, Uri source, string via, bool inlineScript = true)
        {
            if (url == null) throw new Exception("Kippt button must have a url");

            StringBuilder markup = new StringBuilder();

            // Include script
            if (inlineScript) markup.Append(script);

            markup.Append("<a href=\"https://kippt.com/save\" class=\"kippt-save-button\"");

            string pattern = " data-{0}=\"{1}\"";

            markup.AppendFormat(pattern, "url", url.ToString());

            if (string.IsNullOrEmpty(title)) markup.AppendFormat(pattern, "title", title);
            if (source != null) markup.AppendFormat(pattern, "source", source.ToString());
            if (!string.IsNullOrEmpty(via)) markup.AppendFormat(pattern, "via", via);

            markup.Append(">Save To Kippt</a>");

            return new MvcHtmlString(markup.ToString());
        }

        /// <summary>
        /// Renders the script needed for kippt button.
        /// </summary>
        public static MvcHtmlString KipptButtonScript(this HtmlHelper helper)
        {
            return new MvcHtmlString(script);
        }
    }
}
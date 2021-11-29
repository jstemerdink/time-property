using System;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advanced.CMS.TimeProperty
{
    /// <summary>
    /// Renderer for TimeSpan
    /// </summary>
    public static class TimeSpanExtensions
    {
        public static void RenderTimeSpan(this IHtmlHelper htmlHelper, TimeSpan? timespan)
        {
            var viewContext = htmlHelper.ViewContext;
            var contextResolver = ServiceLocator.Current.GetInstance<IContextModeResolver>();

            if (timespan == null)
            {
                if (contextResolver.CurrentMode == ContextMode.Edit)
                {
                    viewContext.Writer.Write("No data");
                }
                return;
            }
            var dateFormat = viewContext.ViewData["DateFormat"] as string;
            if (string.IsNullOrWhiteSpace(dateFormat))
            {
                viewContext.Writer.Write(timespan.Value.ToString());
            }
            else
            {
                viewContext.Writer.Write(new DateTime(timespan.Value.Ticks).ToString(dateFormat));
            }
        }
    }
}

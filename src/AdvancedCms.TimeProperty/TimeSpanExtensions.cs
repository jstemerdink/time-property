using System;
using System.Web.Mvc;
using EPiServer.Editor;

namespace AdvancedCms.TimeProperty
{
    /// <summary>
    /// Renderer for TimeSpan
    /// </summary>
    public static class TimeSpanExtensions
    {
        public static void RenderTimeSpan(this HtmlHelper htmlHelper, TimeSpan? timespan)
        {
            var viewContext = htmlHelper.ViewContext;

            if (timespan == null)
            {
                if (PageEditing.PageIsInEditMode)
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
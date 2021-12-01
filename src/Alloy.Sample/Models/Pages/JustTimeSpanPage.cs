using System;
using Advanced.CMS.TimeProperty;
using EPiServer.DataAnnotations;

namespace Alloy.Sample.Models.Pages
{
    [SiteContentType(GUID = "123C8A41-5C8C-4BE0-8E73-520FF3DE8267")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-standard.png")]
    public class JustTimeSpanPage : SitePageData
    {
        [BackingType(typeof(TimeProperty))]
        [TimePropertySettings(TimePattern = "HH:mm")]
        public virtual TimeSpan? Time1 { get; set; }
    }
}

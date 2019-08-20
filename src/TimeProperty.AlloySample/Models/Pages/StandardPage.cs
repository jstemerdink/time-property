using System;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using AdvancedCms.TimeProperty;

namespace TimeProperty.AlloySample.Models.Pages
{
    /// <summary>
    /// Used for the pages mainly consisting of manually created content such as text, images, and blocks
    /// </summary>
    [SiteContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-standard.png")]
    public class StandardPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 310)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 320)]
        public virtual ContentArea MainContentArea { get; set; }

        [BackingType(typeof(AdvancedCms.TimeProperty.TimeProperty))]
        [TimePropertySettings(TimePattern = "HH:mm", ClickableIncrement = "T00:30:00", VisibleIncrement = "T00:15:00", VisibleRange = "T02:00:00")]
        public virtual TimeSpan? Time1 { get; set; }

    }
}

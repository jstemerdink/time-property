using System;

namespace Advanced.CMS.TimeProperty
{
    /// <summary>
    /// Attribute that allows to configure dojit/Timetextbox constaints
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TimePropertySettingsAttribute: Attribute
    {
        /// <summary>
        /// Time format
        /// </summary>
        public string TimePattern { get; set; }

        public string ClickableIncrement { get; set; }

        public string VisibleIncrement { get; set; }

        public string VisibleRange { get; set; }
    }
}

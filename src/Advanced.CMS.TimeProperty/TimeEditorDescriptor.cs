using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Advanced.CMS.TimeProperty
{
    /// <summary>
    /// EditorDescriptor used to configure <see cref="TimeProperty"/> client editing settings
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(TimeSpan?), UIHint = "Time")]
    public class TimeEditorDescriptor : EditorDescriptor
    {
        public TimeEditorDescriptor()
        {
            ClientEditingClass = "advanced-cms-time-property/TimeEditor";
        }

        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            var settings = attributes.OfType<TimePropertySettingsAttribute>().FirstOrDefault();
            if (settings != null)
            {
                this.EditorConfiguration["constraints"] = GetConstraints(settings);
            }
        }

        /// <summary>
        /// Set dijit/TimeTextbox constraints
        /// </summary>
        /// <param name="settings">Settings attribute</param>
        /// <returns></returns>
        private static Dictionary<string, string> GetConstraints(TimePropertySettingsAttribute settings)
        {
            var editorSettings = new Dictionary<string, string>();
            if (settings.TimePattern != null)
            {
                editorSettings["timePattern"] = settings.TimePattern;
            }

            if (settings.ClickableIncrement != null)
            {
                editorSettings["clickableIncrement"] = settings.ClickableIncrement;
            }

            if (settings.VisibleIncrement != null)
            {
                editorSettings["visibleIncrement"] = settings.VisibleIncrement;
            }

            if (settings.VisibleRange != null)
            {
                editorSettings["visibleRange"] = settings.VisibleRange;
            }

            return editorSettings;
        }
    }
}

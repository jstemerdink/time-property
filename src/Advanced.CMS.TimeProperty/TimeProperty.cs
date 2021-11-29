using System;
using System.Globalization;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;

namespace Advanced.CMS.TimeProperty
{
    /// <summary>
    /// TimeSpan property used to store Time as a number
    /// </summary>
    [EditorHint("Time")]
    [Serializable]
    [PropertyDefinitionTypePlugIn]
    public class TimeProperty : PropertyNumber
    {
        public TimeSpan TimeSpanValue => (TimeSpan)Value;

        public override Type PropertyValueType => typeof(TimeSpan?);

        public override object Value
        {
            get
            {
                var value = base.Value;

                if (value == null)
                {
                    return null;
                }

                if (value is int?)
                {
                    return new TimeSpan((int)value * 10000000L);
                }

                if (value is TimeSpan?)
                {
                    return (TimeSpan?)value;
                }

                return null;
            }
            set
            {
                if (value is TimeSpan?)
                {
                    base.Value = ((TimeSpan)value).Ticks / 10000000L;
                }
                else
                {
                    base.Value = value;
                }

            }
        }

        public override void ParseToSelf(string value)
        {
            if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
            {
                this.Value = new TimeSpan(result);
                return;
            }

            this.Value = null;
        }

        public override object SaveData(PropertyDataCollection properties)
        {
            var value = base.SaveData(properties);
            if (value == null)
            {
                return null;
            }
            return (int)(((TimeSpan) value).Ticks / 10000000L);
        }
    }
}

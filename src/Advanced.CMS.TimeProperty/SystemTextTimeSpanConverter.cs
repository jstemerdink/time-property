using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EPiServer.Shell.Json;

namespace Advanced.CMS.TimeProperty
{
    //Reason for this is to conform with previous newtonsoft behavior
    internal class SystemTextTimeSpanConverter : JsonConverter<TimeSpan>, IJsonConverter
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var timeSpanString = reader.GetString();
            //This is the format we output so that is what we mainly expect as input
            if (TimeSpan.TryParse(timeSpanString, out var timeSpan))
            {
                return timeSpan;
            }

            return default;
        }


        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString());
    }
}

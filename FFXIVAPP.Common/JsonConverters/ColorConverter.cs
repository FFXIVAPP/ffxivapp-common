using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FFXIVAPP.Common.JsonConverters
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var s = (string)reader.Value;
            return Color.Parse(s);
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        /*
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color) || objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

                o.WriteTo(writer);
            }
        }
        */
    }
}
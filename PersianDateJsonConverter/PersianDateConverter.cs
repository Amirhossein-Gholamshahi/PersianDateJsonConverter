using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersianDate;

namespace PersianDateJsonConverter
{
    internal class PersianDateConverter : JsonConverter
    {
        static void Main(string[] args)
        {
            var vacation = new Vacation(1, "amir", 22, DateTime.Now, DateTime.Now.AddDays(5));
            var serilizeTest = JsonConvert.SerializeObject(vacation, Formatting.Indented, new PersianDateConverter());

            var json = @"{
              ""PersonnelId"": 1,
              ""Name"": ""Ali"",
              ""Age"": 22,
              ""StartDate"": ""2024/08/22"",
              ""EndDate"": ""2024/08/29""
            }";

            var deserilizedObject = JsonConvert.DeserializeObject<Vacation>(json, new PersianDateConverter());
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vacation);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            foreach (var property in jsonObject.Properties())
            {
                if (property.Name.EndsWith("date", StringComparison.OrdinalIgnoreCase))
                {
                    property.Value = Convert.ToDateTime(property.Value).ToFa("B");
                }
            }
            return JsonConvert.DeserializeObject<Vacation>(jsonObject.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var myObject = (Vacation)value;
            writer.WriteStartObject();
            foreach (var property in typeof(Vacation).GetProperties(BindingFlags.Public | BindingFlags.Instance)) { 
                writer.WritePropertyName(property.Name);
                var propValue = value.GetType().GetProperty(property.Name).GetValue(value, null);
                if (property.PropertyType == typeof(DateTime))
                {
                    var persiandDate = (DateTime)propValue;
                    writer.WriteValue(persiandDate.ToFa("B"));
                }
                else {
                    writer.WriteValue(propValue);
                } 
            }
            writer.WriteEndObject();
        }

    }
}

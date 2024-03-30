using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace HackAUBG6.Core
{
    public static class JsonSerializationExtension
    {
            public static string SerializeToJson<T>(this T obj)
            {
                var jsonSerializer = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    Converters = new List<Newtonsoft.Json.JsonConverter>()
                {
                    new StringEnumConverter()
                }
                };

                string result = JsonConvert.SerializeObject(obj, jsonSerializer);

                return result;
            }

            public static T DeserializeFromJson<T>(this string jsonString)
            {
                var jsonSerializer = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                T result = JsonConvert.DeserializeObject<T>(jsonString, jsonSerializer);

                return result;
            }
    }
}

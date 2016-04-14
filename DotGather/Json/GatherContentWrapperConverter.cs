using DotGather.GatherContent.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace DotGather.Json
{

    /// <summary>
    /// Converts GatherContent Objects to and from JSON 
    /// </summary>
    /// <typeparam name="T">Object being deserialized into</typeparam>
    public class GatherContentWrapperConverter<T> : JsonConverter where T : class
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// Only return <c>true</c> if given type is object type.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(object) || Type.GetTypeCode(objectType) != TypeCode.Object);
        }

        /// <summary>
        /// Reads the JSON representation of the object. And converts it to 
        /// the taget type ignoring the "data" container from the GatherContent API.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = (JObject)serializer.Deserialize(reader);
            var target = (T)Activator.CreateInstance(objectType);
            serializer.Populate(obj["data"] != null ? obj["data"].CreateReader() : obj.CreateReader(), target);
            return target;
        }


        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jo = new JObject();
            var type = value.GetType();

            foreach (var prop in type.GetProperties().Where(x => x.Name.ToLower() != "project"))
            {
                if (!prop.CanRead) continue;
                var propVal = prop.GetValue(value, null);
                if (propVal != null)
                {
                    if (prop.CustomAttributes.Any(x => x.AttributeType.Name == "JsonPropertyAttribute"))
                    {
                        jo.Add(prop.CustomAttributes.First(x => x.AttributeType.Name == "JsonPropertyAttribute").ConstructorArguments.First().Value.ToString(), JToken.FromObject(propVal, serializer));
                    }
                    else
                    {
                        jo.Add(StringHelpers.ResolvePropertyName(prop.Name), JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }
}

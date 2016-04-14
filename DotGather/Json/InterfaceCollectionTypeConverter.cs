using DotGather.GatherContent.Helpers;
using DotGather.GatherContent.Objects;
using DotGather.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotGather.Json
{
    /// <summary>
    /// Converts collection of GatherContent objects into a collection of their defined interfaces.
    /// </summary>
    /// <typeparam name="TInterface">Defined object interface</typeparam>
    /// <typeparam name="TImplementation">Concrete implementation of defined interface</typeparam>
    public class InterfaceCollectionTypeConverter<TInterface, TImplementation> : JsonConverter where TImplementation : TInterface
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// Always returns <c>true</c> because the defined implementation must 
        /// inherit from the defined interface.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <summary>
        /// Reads the JSON representation of the object. And converts it to 
        /// the taget type ignoring the "data" container from the GatherContent API. 
        /// Then converts the collection of objects into their defined intefaces. 
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var jtr = (JTokenReader)reader;
                if(jtr.CurrentToken.HasValues && jtr.CurrentToken.First.Path.Split('.').Last() == "data")
                    throw new JsonSerializationException();
                var res = serializer.Deserialize<IEnumerable<TImplementation>>(reader);
                return res?.Cast<TInterface>();
            }
            catch(Exception ex)
            {
                var obj = (JObject)serializer.Deserialize(reader);
                if (obj["data"] != null)
                {
                    reader = obj["data"].CreateReader();
                }
                var res = serializer.Deserialize<IEnumerable<TImplementation>>(reader);
                return res.Cast<TInterface>();
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ja = new JArray();
            foreach (var elem in (IEnumerable<TInterface>) value)
            {
                var jo = new JObject();
                TextField textField = null;
                RadioField radioField = null;
                FileField fileField = null;
                SectionField sectionField = null;

                var field = elem as Field;

                switch (field.Type)
                {
                    case "text":
                        textField = field;
                        break;
                    case "files":
                        fileField = field;
                        break;
                    case "section":
                        sectionField = field;
                        break;
                    case "choice_checkbox":
                    case "choice_radio":
                        radioField = field;
                        break;                    
                }

                Type type;
                
                if (textField != null)
                {
                    type = textField.GetType();
                    SetProperty(ref jo, textField, type, serializer);
                }
                else if (radioField != null)
                {
                    type = radioField.GetType();
                    SetProperty(ref jo, radioField, type, serializer);
                    if (radioField.OtherOption)
                    {
                        var lastOption = jo["options"].Last.Previous as JObject;

                        removeValuePropertyFromRadioOptions(ref lastOption);
                    }
                    else
                    {
                        var lastOption = jo["options"].Last as JObject;

                        removeValuePropertyFromRadioOptions(ref lastOption);
                    }
                }
                else if (fileField != null)
                {
                    type = fileField.GetType();
                    SetProperty(ref jo, fileField, type, serializer);
                }
                else if (sectionField != null)
                {
                    type = sectionField.GetType();
                    SetNonFieldProperties(ref jo, sectionField, type, serializer);
                }
                else
                {
                    type = field.GetType();
                    SetProperty(ref jo, field, type, serializer);
                }                      
                
                ja.Add(jo);
            }
            ja.WriteTo(writer);
        }

        private void SetProperty<T>(ref JObject jo, T field, Type type, JsonSerializer serializer) where T : IField
        {
            foreach (var prop in type.GetProperties())
            {
                if (!prop.CanRead) continue;
                var propVal = prop.GetValue(field, null);
                if (propVal != null && !(prop.Name == "OtherOption" && field.Type != "choice_radio"))
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
        }


        private void SetNonFieldProperties<T>(ref JObject jo, T field, Type type, JsonSerializer serializer)
        {
            foreach (var prop in type.GetProperties())
            {
                if (!prop.CanRead) continue;
                var propVal = prop.GetValue(field, null);
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
        }

        private void removeValuePropertyFromRadioOptions(ref JObject lastOption)
        {
            while (lastOption != null)
            {
                lastOption.Remove("value");
                lastOption = lastOption.Previous as JObject;
            }
        }
    }
}

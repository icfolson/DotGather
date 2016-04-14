using Newtonsoft.Json;
using System;

namespace DotGather.Json
{
    /// <summary>
    /// JsonConverter that transforms the path given back as the users avatar path into a valid URI.
    /// </summary>
    public class GatherContentAvatarConverter : JsonConverter
    {
        /// <summary>
        /// This function checks if the input type is of type Uri.
        /// </summary>
        /// <param name="objectType">The input Object Type you wish to check.</param>
        /// <returns>Returns a bool stating the validation of the function. "True" if input type is type Uri.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEquivalentTo(typeof(Uri));
        }

        /// <summary>
        /// Reads and De-serializes the input Json.
        /// </summary>
        /// <param name="reader">The JsonReader reader</param>
        /// <param name="objectType">The Type of the Object</param>
        /// <param name="existingValue">The Existing Value Object</param>
        /// <param name="serializer">The JsonSerializer serializer</param>
        /// <returns>Returns a Uri from the formatted JSON data</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var res = serializer.Deserialize<string>(reader);
            return new Uri($"https://gathercontent-avatars-2.s3.amazonaws.com/{res}");
        }

        /// <summary>
        /// NOT IMPLEMENTED.
        /// Users cannot be created from the GatherContent API,
        /// so serializing the URI is not necessary
        /// </summary>
        /// <param name="writer">Json Writer</param>
        /// <param name="value">Existing Value Object</param>
        /// <param name="serializer">Current serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

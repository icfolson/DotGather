using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace DotGather.Json
{
    /// <summary>
    /// JSON Contract resolver to transform property names from PascalCase property casing to lower_underscore
    /// casing like that which the GatherContent API uses
    /// </summary>
    public class GatherContentContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Transforms the property from pascal to lower underscore casing
        /// </summary>
        /// <param name="propertyName">The name of the Property to be transormed</param>
        /// <returns>Converted property name</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, "(?!(^[A-Z]))([A-Z])", "_$2").ToLower();                       
        }
    }
}

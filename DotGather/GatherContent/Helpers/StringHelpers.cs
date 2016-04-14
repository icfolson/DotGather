using System.Text.RegularExpressions;

namespace DotGather.GatherContent.Helpers
{
    /// <summary>
    /// List of helper methods for formatting strings
    /// </summary>
    public class StringHelpers
    {
        /// <summary>
        /// Formats property names correctly for GatherContent
        /// </summary>
        /// <param name="propertyName">Class property name</param>
        /// <returns>Formatted property name</returns>
        public static string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, "(?!(^[A-Z]))([A-Z])", "_$2").ToLower();
        }
    }
}

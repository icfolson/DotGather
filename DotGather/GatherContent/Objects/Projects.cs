using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of Project Files. We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="Project"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Projects>))]
    public class Projects : List<Project>
    {
    }
}

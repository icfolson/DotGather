using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of GatherContent File Objects. We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="GatherFile"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<GatherFiles>))]
    public class GatherFiles : List<GatherFile>
    {
    }
}

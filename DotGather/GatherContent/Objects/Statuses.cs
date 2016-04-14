using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of Status Files. We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="Status"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Statuses>))]
    public class Statuses : List<Status>
    {
    }
}

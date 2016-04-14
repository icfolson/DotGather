using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of Template Objects.  We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="Template"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Templates>))]
    public class Templates : List<Template>
    {
    }
}

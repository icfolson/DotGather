using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of Page Objects. We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="Page"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Pages>))]
    public class Pages : List<Page>
    {
    }
}

using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// A list of Account objects.  We built this as a separate class to make the JSON deserialzation process more straightforward.
    /// </summary>
    /// <seealso cref="Account"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Accounts>))]
    public class Accounts : List<Account>
    {
    }
}

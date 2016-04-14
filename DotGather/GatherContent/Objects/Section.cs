using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to an element in a GatherContent Config Object.
    /// </summary>
    /// <seealso cref="ISection"/>
    /// <seealso cref="Field"/>
    public class Section : ISection
    {
        /// <summary>The label used to describe a Section</summary>
        public string Label { get; set; }

        /// <summary>The name used to describe a Section</summary>
        public string Name { get; set; }

        /// <summary>Specifies if a Section is Hidden</summary>
        public bool Hidden { get; set; }

        /// <summary>This property represents a collection of Fields</summary>
        /// <seealso cref="Field"/>
        [JsonProperty("elements")]
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<IField, Field>))]
        public IEnumerable<IField> Fields { get; set; }
    }
}

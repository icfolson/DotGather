using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent Status Object.
    /// </summary>
    /// <seealso cref="IStatus"/>
    /// <seealso cref="Statuses"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Status>))]
    public class Status : IStatus
    {
        /// <summary>The unique ID used to identify a Status</summary>
        public int Id { get; set; }

        /// <summary>Specifies if it is the Default Status</summary>
        public bool IsDefault { get; set; }

        /// <summary>Specifies the number position of the Status</summary>
        public int Position { get; set; }

        /// <summary>Specifies the color of the Status</summary>
        public string Color { get; set; }

        /// <summary>The name used to describe a Status</summary>
        public string Name { get; set; }

        /// <summary>The description of the Status</summary>
        public string Description { get; set; }

        /// <summary>Specifies if the Status is Editable</summary>
        public bool CanEdit { get; set; }
    }
}

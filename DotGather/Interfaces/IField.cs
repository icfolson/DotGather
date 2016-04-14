using DotGather.Flags;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Field Object.</summary>
    /// <seealso cref="GatherContent.Objects.Field"/>
    public interface IField
    {
        /// <summary>The name used to describe a Field</summary>
        string Name { get; set; }

        /// <summary>Type of Field</summary>
        string Type { get; set; }
        /// <summary>Specifies if the Field is Required</summary>
        bool Required { get; set; }

        /// <summary>The Label assigned to the Field</summary>
        string Label { get; set; }

        /// <summary>The Microcopy name of the Field</summary>
        string Microcopy { get; set; }
    }
}

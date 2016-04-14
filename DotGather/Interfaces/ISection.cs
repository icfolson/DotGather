using DotGather.GatherContent.Objects;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Section Object.</summary>
    public interface ISection
    {
        /// <summary>The label used to describe a Section</summary>
        string Label { get; set; }

        /// <summary>The name used to describe a Section</summary>
        string Name { get; set; }

        /// <summary>Specifies if a Section is Hidden</summary>
        bool Hidden { get; set; }

        /// <summary>This property represents a collection of Fields</summary>
        /// <seealso cref="Field"/>
        /// <seealso cref="IField"/>
        IEnumerable<IField> Fields { get; set; }
    }
}

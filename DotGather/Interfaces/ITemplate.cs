using DotGather.GatherContent.Objects;
using System;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Template Object.</summary>
    /// <seealso cref="Template"/>
    public interface ITemplate
    {
        /// <summary>The unique ID used to identify a Template</summary>
        int Id { get; set; }

        /// <summary>Identifies a specific Project</summary>
        /// <seealso cref="GatherContent.Objects.Project"/>
        IProject Project { get; }

        /// <summary>The user ID of the person who created the Template</summary>
        int CreatedBy { get; set; }

        /// <summary>The user ID of the person who Updated the Template</summary>
        int UpdatedBy { get; set; }

        /// <summary>The name used to describe the Template</summary>
        string Name { get; set; }

        /// <summary>The description of the Template</summary>
        string Description { get; set; }

        /// <summary>The Date and Time that the Template was Last Used</summary>
        DateTime LastUsed { get; set; }

        /// <summary>The Date and Time that the Template was Created</summary>
        DateTime Created { get; set; }

        /// <summary>The Date and Time that the Template was Updated</summary>
        DateTime Updated { get; set; }

        /// <summary>The number of times the Template is used</summary>
        int UsingCount { get; set; }

        /// <summary>This property represents a collection of Sections</summary>
        /// <seealso cref="Section"/>
        IEnumerable<ISection> Sections { get; set; }
    }
}

using DotGather.GatherContent.Objects;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Project Object.</summary>
    /// <seealso cref="Project"/>
    public interface IProject
    {
        /// <summary>The unique ID used to identify a Project</summary>
        int Id { get; set; }

        /// <summary>The name used to describe a Project</summary>
        string Name { get; set; }

        /// <summary>The unique ID used to identify an Account</summary>
        int AccountId { get; set; }

        /// <summary>identifies a specific Account</summary>
        /// <seealso cref="GatherContent.Objects.Account"/>
        IAccount Account { get; set; }

        /// <summary>Specifies if an Account is Active</summary>
        bool Active { get; set; }

        /// <summary>Specifies the text direction</summary>
        string TextDirection { get; set; }

        /// <summary>Specifies if tags are allowed</summary>
        string AllowedTags { get; set; }

        /// <summary>Specifies if the Date has passed</summary>
        bool Overdue { get; set; }

        /// <summary>This property represents a collection of Statuses</summary>
        /// <seealso cref="Status"/>
        IEnumerable<IStatus> Statuses { get; set; }

        /// <summary>Represents the meta-data used</summary>
        /// <seealso cref="IProjectMetadata"/>
        IProjectMetadata Metadata { get; set; }
    }
}

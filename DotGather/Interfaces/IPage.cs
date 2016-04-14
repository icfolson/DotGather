using DotGather.GatherContent.Objects;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a GatherContent Page.</summary>
    /// <seealso cref="Page"/>
    public interface IPage
    {
        /// <summary>The unique ID used to identify a Page</summary>
        int Id { get; set; }

        /// <summary>The unique ID used to identify a Project</summary>
        int ProjectId { get; set; }

        /// <summary>The unique ID used to identify a Parent Page</summary>
        int ParentId { get; set; }

        /// <summary>This property represents a Parent Page</summary>
        IPage Parent { get; set; }

        /// <summary>The unique ID used to identify a Template</summary>
        int? TemplateId { get; set; }

        /// <summary>The unique ID used to identify a Custom state</summary>
        int CustomStateId { get; set; }

        /// <summary>The tree Position of the Page</summary>
        int Position { get; set; }

        /// <summary>The name used to describe a Page</summary>
        string Name { get; set; }

        /// <summary>This property represents a collection of Sections on the Page</summary>
        /// <seealso cref="Section"/>
        IEnumerable<ISection> ContentSections { get; set; }

        /// <summary>A note on the specified Page</summary>
        string Notes { get; set; }

        /// <summary>The Type of the Page</summary>
        string Type { get; set; }

        /// <summary>The Due Date status</summary>
        bool Overdue { get; set; }

        /// <summary>The Date and Time the Page was Created</summary>
        IDate Created { get; set; }

        /// <summary>The Date and Time the Page was Updated</summary>
        IDate Updated { get; set; }

        /// <summary>The Status of the Page</summary>
        /// <seealso cref="Status"/>
        Status Status { get; set; }

        /// <summary>This property represents a collection of DueDate Objects</summary>
        /// <seealso cref="DueDate"/>
        IEnumerable<IDueDate> DueDates { get; set; }

        /// <summary>This Page's list of children Pages.</summary>
        /// <seealso cref="Page"/>
        IEnumerable<IPage> Children { get; set; }


    }
}

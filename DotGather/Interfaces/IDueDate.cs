using DotGather.GatherContent.Objects;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a DueDate Object.</summary>
    /// <seealso cref="DueDate"/>
    public interface IDueDate
    {
        /// <summary>The unique ID used to identify a DueDate</summary>
        int StatusId { get; set; }

        /// <summary>Specifies if the Date has passed</summary>
        bool Overdue { get; set; }

        /// <summary>The Date and Time when someone is due.</summary>
        /// <seealso cref="GatherContentDate"/>
        IDate Date { get; set; }
    }
}

using DotGather.Interfaces;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    ///  This class maps to a GatherContent DueDate Object.
    /// </summary>
    /// <seealso cref="IDueDate"/>
    /// <seealso cref="Page"/>

    public class DueDate : IDueDate
    {
        /// <summary>The unique ID used to identify a DueDate</summary>
        public int StatusId { get; set; }

        /// <summary>Specifies if the Date has passed</summary>
        public bool Overdue { get; set; }

        /// <summary>This property represents a Date and Time</summary>
        /// <seealso cref="GatherContentDate"/>
        public IDate Date { get; set; }
    }
}

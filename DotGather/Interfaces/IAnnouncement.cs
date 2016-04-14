using DotGather.GatherContent.Objects;

namespace DotGather.Interfaces
{
    /// <summary>The required behvaior for a Announcement Object.</summary>
    /// <seealso cref="Announcement"/>
    public interface IAnnouncement
    {
        /// <summary>The unique ID used to identify an Announcement</summary>
        int Id { get; set; }

        /// <summary>The name used to describe an Announcement</summary>
        string Name { get; set; }

        /// <summary>Identifies if an Announcement was acknowledged</summary>
        bool Acknowledged { get; set; }
    }
}

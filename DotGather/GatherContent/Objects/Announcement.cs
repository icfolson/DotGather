using DotGather.Interfaces;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to the GatherContent Announcement object.
    /// </summary>
    /// <seealso cref="IAnnouncement"/>
    /// <seealso cref="User"/>
    public class Announcement : IAnnouncement
    {
        /// <summary>The unique ID used to identify an Announcement</summary>
        public int Id { get; set; }

        /// <summary>The name used to describe an Announcement</summary>
        public string Name { get; set; }

        /// <summary>Identifies if an Announcement was acknowledged</summary>
        public bool Acknowledged { get; set; }
    }
}

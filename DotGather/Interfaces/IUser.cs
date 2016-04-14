using DotGather.GatherContent.Objects;
using System;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a User Object.</summary>
    /// <seealso cref="User"/>
    public interface IUser
    {
        /// <summary>The User's Email address</summary>
        string Email { get; set; }

        /// <summary>The User's First Name</summary>
        string FirstName { get; set; }

        /// <summary>The User's Last Name</summary>
        string LastName { get; set; }

        /// <summary>The User's current Timezone</summary>
        string Timezone { get; set; }

        /// <summary>The User's Language</summary>
        string Language { get; set; }

        /// <summary>The User's Gender</summary>
        string Gender { get; set; }

        /// <summary>The User's Avatar</summary>
        Uri Avatar { get; set; }

        /// <summary>This property represents a collection of Announcements</summary>
        /// <seealso cref="Announcement"/>
        IEnumerable<IAnnouncement> Announcements { get; set; }
    }
}

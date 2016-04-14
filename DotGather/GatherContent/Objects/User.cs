using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent User Object.
    /// </summary>
    /// <seealso cref="IUser"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<User>))]
    public class User : IUser
    {
        /// <summary>The User's Email address</summary>
        public string Email { get; set; }

        /// <summary>The User's First Name</summary>
        public string FirstName { get; set; }

        /// <summary>The User's Last Name</summary>
        public string LastName { get; set; }

        /// <summary>The User's current Timezone</summary>
        public string Timezone { get; set; }

        /// <summary>The User's Language</summary>
        public string Language { get; set; }

        /// <summary>The User's Gender</summary>
        public string Gender { get; set; }

        /// <summary>The User's Avatar</summary>
        [JsonConverter(typeof(GatherContentAvatarConverter))]
        public Uri Avatar { get; set; }

        /// <summary>This property represents a collection of Announcements</summary>
        /// <seealso cref="Announcement"/>
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<IAnnouncement, Announcement>))]
        public IEnumerable<IAnnouncement> Announcements { get; set; }
    }
}

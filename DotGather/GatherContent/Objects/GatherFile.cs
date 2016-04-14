using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent file Object.  We made the name explicitly reference GatherContent so as to not confuse this class 
    /// with the .NET File Object.
    /// </summary>
    /// <seealso cref="IFile"/>
    /// <seealso cref="GatherFiles"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<GatherFile>))]
    public class GatherFile : IFile
    {
        /// <summary>The unique ID used to identify a File</summary>
        public int Id { get; set; }

        /// <summary>The unique ID used to identify a User</summary>
        public int UserId { get; set; }

        /// <summary>The unique ID used to identify an Item</summary>
        public int ItemId { get; set; }

        /// <summary>The Field name that is assigned to the File</summary>
        public string Field { get; set; }

        /// <summary>The assigned File Type</summary>
        public string Type { get; set; }

        /// <summary>The assigned File Url</summary>
        public Uri Url { get; set; }

        /// <summary>The name used to identify a File</summary>
        public string Filename { get; set; }

        /// <summary>The size of the File</summary>
        public int Size { get; set; }

        /// <summary>The Date and Time the File was Created</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>The Date and Time the File was Updated</summary>
        public DateTime UpdatedAt { get; set; }
    }
}

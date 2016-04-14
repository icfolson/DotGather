using DotGather.GatherContent.Objects;
using System;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a GatherContent File.</summary>
    /// <seealso cref="GatherFile"/>
    public interface IFile
    {
        /// <summary>The unique ID used to identify a File</summary>
        int Id { get; set; }

        /// <summary>The unique ID used to identify a User</summary>
        int UserId { get; set; }

        /// <summary>The unique ID used to identify an Item</summary>
        int ItemId { get; set; }

        /// <summary>The Field name that is assigned to the File</summary>
        string Field { get; set; }

        /// <summary>The assigned File Type</summary>
        string Type { get; set; }

        /// <summary>The assigned File Url</summary>
        Uri Url { get; set; }

        /// <summary>The name used to identify a File</summary>
        string Filename { get; set; }

        /// <summary>The size of the File</summary>
        int Size { get; set; }

        /// <summary>The Date and Time the File was Created</summary>
        DateTime CreatedAt { get; set; }

        /// <summary>The Date and Time the File was Updated</summary>
        DateTime UpdatedAt { get; set; }
    }
}

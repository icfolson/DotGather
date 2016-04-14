using DotGather.GatherContent.Objects;
using System;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Date Object.</summary>
    /// <seealso cref="GatherContentDate"/>
    public interface IDate
    {
        /// <summary>The specified Date and Time</summary>
        DateTime Date { get; set; }

        /// <summary>The specified Timezone Type</summary>
        int TimezoneType { get; set; }

        /// <summary>The specified Timezone</summary>
        string Timezone { get; set; }
    }
}

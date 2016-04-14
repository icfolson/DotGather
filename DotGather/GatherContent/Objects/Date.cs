using DotGather.Interfaces;
using System;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent Date Object.
    ///</summary>
    /// <seealso cref="IDate"/>
    /// <seealso cref="Page"/>    
    public class GatherContentDate : IDate
    {
        /// <summary>The specified Date and Time</summary>
        public DateTime Date { get; set; }

        /// <summary>The specified Timezone Type</summary>
        public int TimezoneType { get; set; }

        /// <summary>The specified Timezone</summary>
        public string Timezone { get; set; }
    }
}

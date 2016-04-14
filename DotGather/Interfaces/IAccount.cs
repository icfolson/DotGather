using DotGather.GatherContent.Objects;
using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for an Account Object.</summary>
    /// <seealso cref="Account"/>
    public interface IAccount
    {
        /// <summary>The unique ID used to identify an Account</summary>
        int Id { get; set; }

        /// <summary>The name used to describe an Account</summary>
        string Name { get; set; }

        /// <summary>The Account's Url Key</summary>
        string UrlKey { get; set; }

        /// <summary>The Account's TimeZone</summary>
        string Timezone { get; set; }

        /// <summary>A collection of Projects that this Account has access to</summary>
        /// <seealso cref="Project"/>
        IEnumerable<IProject> Projects { get; }
    }
}

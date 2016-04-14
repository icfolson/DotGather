using DotGather.GatherContent.Service;
using DotGather.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to the GatherContent Account object.
    /// </summary>
    /// <seealso cref="IAccount"/>    
    /// <seealso cref="Accounts"/>    
    public class Account : IAccount
    {
        private Lazy<IEnumerable<IProject>> _projects;

        /// <summary>Default constructor</summary>
        public Account()
        {
            _projects = new Lazy<IEnumerable<IProject>>(() => SetProjects());
        }

        /// <summary>The unique ID used to identify an Account</summary>
        public int Id { get; set; }

        /// <summary>The name used to describe an Account</summary>
        public string Name { get; set; }

        /// <summary>The Account's Url Key</summary>
        [JsonProperty("slug")]
        public string UrlKey { get; set; }

        /// <summary>The Account's TimeZone</summary>
        public string Timezone { get; set; }

        /// <summary>A collection of Projects that this Account has access to.</summary>
        /// <seealso cref="Project"/>
        public IEnumerable<IProject> Projects
        {
            get
            {
                return _projects.Value;
            }
        }

        private IEnumerable<IProject> SetProjects()
        {
            var service = new GatherContentService("projects?account_id="+this.Id);
            return service.GetSingleObjectRequest<Projects>();
        }
    }
}

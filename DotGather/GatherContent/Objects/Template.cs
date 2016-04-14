using DotGather.Interfaces;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DotGather.GatherContent.Service;
using DotGather.Json;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent Template Object.
    /// </summary>
    [JsonConverter(typeof(GatherContentWrapperConverter<Template>))]
    public class Template : ITemplate
    {
        private Lazy<IProject> _project;

        /// <summary>Initialize Template with a new Lazy IProject</summary>
        public Template()
        {
            _project = new Lazy<IProject>(() => SetProject());
        }

        /// <summary>The Project this Template is under.</summary>
        public IProject Project
        {
            get
            {
                return _project.Value;
            }
        }

        /// <summary>The unique ID used to identify a Template</summary>
        public int Id { get; set; }

        /// <summary>The Id of the Project this Template is under.</summary>
        public int ProjectId { get; set; }

        /// <summary>The user ID of the person who created the Template</summary>
        public int CreatedBy { get; set; }

        /// <summary>The user ID of the person who Updated the Template</summary>
        public int UpdatedBy { get; set; }

        /// <summary>The name used to describe the Template</summary>
        public string Name { get; set; }

        /// <summary>The description of the Template</summary>
        public string Description { get; set; }

        /// <summary>The Date and Time that the Template was Last Used</summary>
        public DateTime LastUsed { get; set; }

        /// <summary>The Date and Time that the Template was Created</summary>
        public DateTime Created { get; set; }

        /// <summary>The Date and Time that the Template was Updated</summary>
        public DateTime Updated { get; set; }

        /// <summary>The number of times the Template is used</summary>
        public int UsingCount { get; set; }

        /// <summary>This property represents a collection of Sections</summary>
        /// <seealso cref="Section"/>
        [JsonProperty("config")]
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<ISection, Section>))]
        public IEnumerable<ISection> Sections { get; set; }


        private IProject SetProject()
        {
            var service = new GatherContentService("projects/" + this.ProjectId);
            return service.GetSingleObjectRequest<Project>();
        }
    }
}

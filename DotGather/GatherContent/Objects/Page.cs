using DotGather.GatherContent.Service;
using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This maps to a GatherContent Item Object.
    /// </summary>
    /// <seealso cref="IPage"/>
    /// <seealso cref="Pages"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Page>))]
    public class Page : IPage
    {
        private Lazy<IProject> _project;
        private Lazy<IPage> _parent;
        private IPage _givenParent;

        /// <summary>Default Constructor</summary>
        public Page()
        {
            _project = new Lazy<IProject>(() => SetProject());
            _parent = new Lazy<IPage>(() => SetParent());

        }

        /// <summary>The Project this Page is located in.</summary>
        public IProject Project
        {
            get
            {
                return _project.Value;
            }
        }

        /// <summary>The unique ID used to identify a Page</summary>
        public int Id { get; set; }

        /// <summary>The Id of the Project this Page is located in.</summary>
        public int ProjectId { get; set; }

        /// <summary>The Id of this Page's Parent.</summary>
        public int ParentId { get; set; }

        /// <summary>The Parent Page this GatherContent Item is under.</summary>
        /// <seealso cref="Page"/>
        public IPage Parent
        {
            get
            {
                if (_givenParent == null)
                {
                    return _parent.Value;
                }
                return _givenParent;
            }
            set
            {
                _givenParent = value;
            }
        }

        /// <summary>The unique ID used to identify a Template</summary>
        public int? TemplateId { get; set;}

        /// <summary>The unique ID used to identify a Custom state</summary>
        public int CustomStateId { get; set; }

        /// <summary>The tree Position of the Page</summary>
        public int Position { get; set; }

        /// <summary>The name used to describe a Page</summary>
        public string Name { get; set; }

        /// <summary>This property represents a collection of Sections on the Page</summary>
        /// <seealso cref="Section"/>
        [JsonProperty("config")]
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<ISection, Section>))]    
        public IEnumerable<ISection> ContentSections { get; set; }

        /// <summary>A note on the specified Page</summary>
        public string Notes { get; set; }

        /// <summary>The Type of the Page</summary>
        public string Type { get; set; }

        /// <summary>The Due Date status</summary>
        public bool Overdue { get; set; }

        /// <summary>The Date and Time the Page was Created</summary>
        public IDate Created { get; set; }

        /// <summary>The Date and Time the Page was Updated</summary>
        public IDate Updated { get; set; }

        /// <summary>The Status of the Page</summary>
        public Status Status { get; set; }

        /// <summary>This property represents a collection of DueDate Objects</summary>
        /// <seealso cref="DueDate"/>
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<IDueDate, DueDate>))]
        public IEnumerable<IDueDate> DueDates { get; set; }

        /// <summary>This Page's list of child Pages.</summary>
        /// <seealso cref="Page"/>
        public IEnumerable<IPage> Children { get; set; }

        private IProject SetProject()
        {
            var service = new GatherContentService("projects/" + this.ProjectId);
            return service.GetSingleObjectRequest<Project>();
        }

        private IPage SetParent()
        {
            if (this.ParentId != 0)
            {
                var service = new GatherContentService("items/" + this.ParentId);
                return service.GetSingleObjectRequest<Page>();
            }
            return null;
        }
    }
}

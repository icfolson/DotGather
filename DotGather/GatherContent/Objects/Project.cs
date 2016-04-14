using DotGather.GatherContent.Helpers;
using DotGather.GatherContent.Service;
using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent Project Object.
    /// </summary>
    /// <seealso cref="IProject"/>
    /// <seealso cref="Projects"/>
    [JsonConverter(typeof(GatherContentWrapperConverter<Project>))]
    public class Project : IProject
    {
        private Lazy<IEnumerable<IPage>> _items;

        /// <summary>Default Constructor</summary>
        public Project()
        {
            _items = new Lazy<IEnumerable<IPage>>(() => organizeItems());
        }

        /// <summary>The list of Pages in this Project</summary>
        public IEnumerable<IPage> Items
        {
            get
            {
                return _items.Value;
            }
        }

        /// <summary>The unique ID used to identify a Project</summary>
        public int Id { get; set; }

        /// <summary>The name used to describe a Project</summary>
        public string Name { get; set; }

        /// <summary>The unique ID used to identify an Account</summary>
        public int AccountId { get; set; }

        /// <summary>Identifies a specific Account</summary>
        /// <seealso cref="Account"/>
        public IAccount Account { get; set; }

        /// <summary>Specifies if an Account is Active</summary>
        public bool Active { get; set; }

        /// <summary>Specifies the text direction</summary>
        public string TextDirection { get; set; }

        /// <summary>Specifies if tags are allowed</summary>
        public string AllowedTags { get; set; }

        /// <summary>Specifies if the Date has passed</summary>
        public bool Overdue { get; set; }

        /// <summary>This property represents a collection of Statuses</summary>
        /// <seealso cref="Statuses"/>
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<IStatus, Status>))]
        public IEnumerable<IStatus> Statuses { get; set; }

        /// <summary>Represents the meta-data used</summary>
        /// <seealso cref="IProjectMetadata"/>
        public IProjectMetadata Metadata { get; set; }

        private IEnumerable<IPage> organizeItems()
        {
            var service = new GatherContentService("items");
            var unorganizedItems = service.GetItems(this.Id);
            return GatherContentProjectOrganizer.OrganizeProject(unorganizedItems);
        }
    }
}

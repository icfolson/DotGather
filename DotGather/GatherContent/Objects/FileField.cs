using DotGather.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotGather.GatherContent.Objects
{
    public class FileField : IField
    {
        /// <summary>The name used to describe a Field</summary>
        public string Name { get; set; }

        /// <summary>Type of Field</summary>
        public string Type { get; set; }
        /// <summary>Specifies if the Field is Required</summary>
        public bool Required { get; set; }

        /// <summary>The Label assigned to the Field</summary>
        public string Label { get; set; }

        /// <summary>The Microcopy name of the Field</summary>
        public string Microcopy { get; set; }

        public static implicit operator FileField(Field field)
        {
            return new FileField
            {
                Name = field.Name,
                Label = field.Label,
                Microcopy = field.Microcopy,
                Required = field.Required,
                Type = field.Type
            };
        }
    }
}

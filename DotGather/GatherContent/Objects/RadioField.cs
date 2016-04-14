using DotGather.Interfaces;
using System.Collections.Generic;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent RadioField Object. It is a more specific Field Object.
    /// </summary>
    /// <seealso cref="IRadioField"/>
    /// <seealso cref="Field"/>
    public class RadioField : IField, IRadioField
    {
        /// <summary>The name used to describe a Field</summary>
        public string Name { get; set; }

        /// <summary>Specifies if the Field is Required</summary>
        public bool Required { get; set; }

        /// <summary>The Label assigned to the Field</summary>
        public string Label { get; set; }

        /// <summary>Type of Field</summary>
        public string Type { get; set; }

        /// <summary>The Microcopy name of the Field</summary>
        public string Microcopy { get; set; }

        /// <summary>Is the field an option field</summary>
        public bool OtherOption { get; set; }

        /// <summary>The Radio Options</summary>
        public IEnumerable<IRadioOption> Options { get; set; }

        public static implicit operator RadioField (Field field)
        {
            return new RadioField
            {
                Name = field.Name,
                Label = field.Label,
                Microcopy = field.Microcopy,
                Options = field.Options,
                OtherOption = field.OtherOption,
                Required = field.Required,
                Type = field.Type
            };
        }
    }
}

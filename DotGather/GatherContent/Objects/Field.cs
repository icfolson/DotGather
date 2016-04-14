using System.Collections.Generic;
using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent Field Object.
    ///</summary>
    /// <seealso cref="IField"/>
    /// <seealso cref="Section"/>

    public class Field : IField, IRadioField, ITextField
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

        /// <summary>Is the field an option field</summary>
        public bool OtherOption { get; set; }

        /// <summary>The Radio Options</summary>
        [JsonConverter(typeof(InterfaceCollectionTypeConverter<IRadioOption, RadioOption>))]
        public IEnumerable<IRadioOption> Options { get; set; }

        /// <summary>The value used in the Text Field</summary>
        public string Value { get; set; }

        /// <summary>The Type that the Text Field is limited in using</summary>
        public string LimitType { get; set; }

        /// <summary>The number of character limit of the Text Field</summary>
        public int Limit { get; set; }

        /// <summary>Specifies if the Text Field is only Text</summary>
        public bool PlainText { get; set; }

        public string Subtitle { get; set; }
        public string Title { get; set; }
    }
}

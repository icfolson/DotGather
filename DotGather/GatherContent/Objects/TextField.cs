using DotGather.Interfaces;

namespace DotGather.GatherContent.Objects
{
    /// <summary>
    /// This class maps to a GatherContent TextField Object. It is a more specific Field Object.
    /// </summary>
    /// <seealso cref="ITextField"/>
    /// <seealso cref="Field"/>
    public class TextField : IField, ITextField
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

        /// <summary>The value used in the Text Field</summary>
        public string Value { get; set; }

        /// <summary>The Type that the Text Field is limited in using</summary>
        public string LimitType { get; set; }

        /// <summary>The number of character limit of the Text Field</summary>
        public int Limit { get; set; }

        /// <summary>Specifies if the Text Field is only Text</summary>
        public bool PlainText { get; set; }

        public static implicit operator TextField (Field field)
        {
            return new TextField
            {
                Name = field.Name,
                Label = field.Label,
                Limit = field.Limit,
                LimitType = field.LimitType,
                Microcopy = field.Microcopy,
                PlainText = field.PlainText,
                Required = field.Required,
                Type = field.Type,
                Value = field.Value
            };
        }
    }
}

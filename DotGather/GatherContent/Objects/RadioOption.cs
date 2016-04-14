using DotGather.Interfaces;

namespace DotGather.GatherContent.Objects
{
    /// <summary>Option type for radio/multi select fields</summary>
    /// <seealso cref="IRadioOption"/>
    public class RadioOption : IRadioOption
    {
        /// <summary>Radio Option Label</summary>
        public string Label { get; set; }

        /// <summary>Radio Option Name</summary>
        public string Name { get; set; }

        /// <summary>Is this the selected Radio Option?</summary>
        public bool Selected { get; set; }

        public string Value { get; set; }
    }
}

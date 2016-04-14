namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a RadioOption Object.</summary>
    public interface IRadioOption
    {
        /// <summary>The label associated with this RadioOption </summary>
        string Label { get; set; }
        /// <summary>Is this RadioOption Selected?</summary>
        bool Selected { get; set; }
        /// <summary>Name of this RadioOption </summary>
        string Name { get; set; }

        string Value { get; set; }
    }
}

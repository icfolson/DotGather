namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Text Field Object.</summary>
    public interface ITextField : IField
    {
        /// <summary>The value used in the Text Field</summary>
        string Value { get; set; }

        /// <summary>The Type that the Text Field is limited in using</summary>
        string LimitType { get; set; }

        /// <summary>The number of character limit of the Text Field</summary>
        int Limit { get; set; }

        /// <summary>Specifies if the Text Field is only Text</summary>
        bool PlainText { get; set; }
    }
}

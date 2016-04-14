namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a Status Object.</summary>
    public interface IStatus
    {
        /// <summary>The unique ID used to identify a Status</summary>
        int Id { get; set; }

        /// <summary>Specifies if it is the Default Status</summary>
        bool IsDefault { get; set; }

        /// <summary>Specifies the number position of the Status</summary>
        int Position { get; set; }

        /// <summary>Specifies the color of the Status</summary>
        string Color { get; set; }

        /// <summary>The name used to describe a Status</summary>
        string Name { get; set; }

        /// <summary>The description of the Status</summary>
        string Description { get; set; }

        /// <summary>Specifies if the Status is Editable</summary>
        bool CanEdit { get; set; }
    }
}

namespace DotGather.Interfaces
{
    /// <summary>The required behavior for a ProjectMetadata Object.</summary>
    public interface IProjectMetadata
    {
        /// <summary>
        /// Specifies the number of Templates used.
        /// </summary>
        int Templates { get; set; }
    }
}

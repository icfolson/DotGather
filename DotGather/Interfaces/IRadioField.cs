using System.Collections.Generic;

namespace DotGather.Interfaces
{
    /// <summary>
    /// The required behavior for a RadioField Object.
    /// </summary>
    public interface IRadioField : IField
    {
        bool OtherOption { get; set; }
        IEnumerable<IRadioOption> Options { get; set; }
    }
}

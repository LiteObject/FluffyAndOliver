namespace FluffyAndOliver.Shared.Interfaces
{
    using FluffyAndOliver.Shared.Enums;

    /// <summary>
    /// The StateObject interface.
    /// </summary>
    public interface IStateObject
    {
        /// <summary>
        /// Gets the state.
        /// </summary>
        ObjectState State { get; }
    }
}

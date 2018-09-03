namespace FluffyAndOliver.Shared
{
    using System;

    /// <summary>
    /// The value object.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }
    }
}

namespace FluffyAndOliver.Shared.Contracts
{
    /// <summary>
    /// The Discount interface.
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="total">
        /// The total.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        decimal Calculate(decimal total);
    }
}

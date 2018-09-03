namespace FluffyAndOliver.Domain.Models
{
    using System;

    using FluffyAndOliver.Domain.Contracts;

    /// <summary>
    /// The holiday discount.
    /// </summary>
    public class HolidayDiscount : IDiscount
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
        public decimal Calculate(decimal total)
        {
            throw new NotImplementedException();
        }
    }
}

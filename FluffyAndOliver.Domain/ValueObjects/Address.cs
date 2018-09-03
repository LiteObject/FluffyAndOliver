namespace FluffyAndOliver.Domain.ValueObjects
{
    using FluffyAndOliver.Shared;

    /// <summary>
    /// The address.
    /// </summary>
    public class Address : ValueObject<Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// Needs for EF queries
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="street">
        /// The street.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="stateProvince">
        /// The state province.
        /// </param>
        /// <param name="postalCode">
        /// The postal code.
        /// </param>
        private Address(string street, string city, string stateProvince, string postalCode)
        {
            this.Street = street;
            this.City = city;
            this.StateProvince = stateProvince;
            this.PostalCode = postalCode;
        }

        /// <summary>
        /// Gets the street.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the state province.
        /// </summary>
        public string StateProvince { get; private set; }

        /// <summary>
        /// Gets the postal code.
        /// </summary>
        public string PostalCode { get; private set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="street">
        /// The street.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="stateProvince">
        /// The state province.
        /// </param>
        /// <param name="postalCode">
        /// The postal code.
        /// </param>
        /// <returns>
        /// The <see cref="Address"/>.
        /// </returns>
        public static Address Create(string street, string city, string stateProvince, string postalCode)
        {
            return new Address(street, city, stateProvince, postalCode);
        }
    }
}

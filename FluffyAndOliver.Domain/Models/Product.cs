namespace FluffyAndOliver.Domain.Models
{
    using FluffyAndOliver.Shared;

    /// <summary>
    /// The product.
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double Price { get; set; }
    }
}
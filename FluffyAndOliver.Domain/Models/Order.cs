namespace FluffyAndOliver.Domain.Models
{
    using System.Collections.Generic;

    using FluffyAndOliver.Shared;

    /// <summary>
    /// The order.
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Order(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
   
        /// <summary>
        /// The create product.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        public Product CreateProduct(string name, double price)
        {
            var product = new Product(name, price);
            this.Products.Add(product);

            return product;
        }
    }
}

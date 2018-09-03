namespace FluffyAndOliver.Domain.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The order.
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// The products.
        /// </summary>
        private readonly List<Product> products = new List<Product>();

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
            this.products.Add(product);

            return product;
        }
    }
}

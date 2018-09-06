namespace FluffyAndOliver.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using FluffyAndOliver.Domain.ValueObjects;
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
        /// Gets or sets the address.
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets the products.
        /// </summary>
        public List<OrderedProduct> Products { get; } = new List<OrderedProduct>();
   
        /// <summary>
        /// The add product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        public void AddProduct(Product product)
        {
            var orderedProduct = new OrderedProduct { OrderId = this.Id, ProductId = product.Id, Product = product};
            this.Products.Add(orderedProduct);

            // raise event or perform other tasks
        }

        /// <summary>
        /// The get total price.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetTotalPrice()
        {
            return this.Products.Sum(p => p.Product.Price);
        }
    }
}

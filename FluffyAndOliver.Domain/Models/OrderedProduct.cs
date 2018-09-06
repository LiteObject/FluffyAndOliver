namespace FluffyAndOliver.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FluffyAndOliver.Shared;

    /// <summary>
    /// The ordered product.
    /// </summary>
    public class OrderedProduct : Entity
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }
    }
}

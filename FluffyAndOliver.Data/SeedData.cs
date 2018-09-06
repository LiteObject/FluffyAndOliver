namespace FluffyAndOliver.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FluffyAndOliver.Domain.Models;

    /// <summary>
    /// The seed data.
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// The get orders.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<Order> GetOrders()
        {
            return new List<Order>()
                       {
                           new Order("Order One")
                               {
                                   Id = 1, Name = "Order One"
                               },
                           new Order("Order Two")
                               {
                                   Id = 2, Name = "Order Two"
                               }
                       };
        }

        /// <summary>
        /// The get products.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<Product> GetProducts()
        {
            return new List<Product>()
                       {
                           new Product("Product One", 1.99) { Id = 1 },
                           new Product("Product Two", 2.99) { Id = 2 },
                           new Product("Product Three", 3.99) { Id = 3 },
                       };
        }

        /// <summary>
        /// The get ordered product.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<OrderedProduct> GetOrderedProducts()
        {
            return new List<OrderedProduct>
                       {
                           new OrderedProduct
                               {
                                   Id = 1,
                                   OrderId = GetOrders()[0].Id,
                                   ProductId = GetProducts()[0].Id
                               },
                           new OrderedProduct
                               {
                                   Id = 2,
                                   OrderId = GetOrders()[0].Id,
                                   ProductId = GetProducts()[1].Id
                               },
                           new OrderedProduct
                               {
                                   Id = 3,
                                   OrderId = GetOrders()[1].Id,
                                   ProductId = GetProducts()[2].Id
                               },
                       };
        }
    }
}

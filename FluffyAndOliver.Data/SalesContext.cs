namespace FluffyAndOliver.Data
{
    using FluffyAndOliver.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    /// <summary>
    /// The order context.
    /// </summary>
    public class SalesContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesContext"/> class.
        /// </summary>
        public SalesContext()
        {
        }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=FluffyAndOliver;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure()); // Connection Resiliency

            optionsBuilder.UseLoggerFactory(
                new LoggerFactory(
                    new[]
                        {
                            new ConsoleLoggerProvider(
                                (category, level) =>
                                    category == DbLoggerCategory.Database.Command.Name
                                    && level == LogLevel.Information,
                                true)
                        }));
        }
    }
}

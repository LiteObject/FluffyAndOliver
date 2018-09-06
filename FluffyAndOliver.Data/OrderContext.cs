namespace FluffyAndOliver.Data
{
    using System;
    using System.Linq;

    using FluffyAndOliver.Data.Extensions;
    using FluffyAndOliver.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    /// <summary>
    /// The order context.
    /// </summary>
    public class OrderContext : DbContext
    {
        /// <summary>
        /// The seed.
        /// </summary>
        private readonly bool seed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderContext"/> class.
        /// </summary>
        public OrderContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderContext"/> class.
        /// </summary>
        /// <param name="seed">
        /// The seed.
        /// </param>
        public OrderContext(bool seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;

            foreach (var entry in this.ChangeTracker.Entries().Where(e =>
                (e.State == EntityState.Added || e.State == EntityState.Modified)
                && !e.Metadata.IsOwned()))
            {
                entry.Property("ModifiedOn").CurrentValue = timestamp;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOn").CurrentValue = timestamp;
                }
            }

            return base.SaveChanges();
        }

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

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.seed)
            {
                modelBuilder.Seed();
            }

            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);

            base.OnModelCreating(modelBuilder);
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeContext.cs" company="LiteObject">
//   
// </copyright>
// <summary>
//   The employee context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluffyAndOliver.Data
{
    using FluffyAndOliver.Data.Extensions;
    using FluffyAndOliver.Domain.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    /// <summary>
    /// The employee context.
    /// </summary>
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// The seed.
        /// </summary>
        private readonly bool seed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeContext"/> class.
        /// </summary>
        public EmployeeContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeContext"/> class.
        /// </summary>
        /// <param name="seed">
        /// The seed.
        /// </param>
        public EmployeeContext(bool seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}

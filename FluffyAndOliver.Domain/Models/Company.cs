namespace FluffyAndOliver.Domain.Models
{
    using System.Collections.Generic;

    using FluffyAndOliver.Shared;

    /// <summary>
    /// The company.
    /// </summary>
    public class Company : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public virtual List<Employee> Employees { get; set; }
    }
}

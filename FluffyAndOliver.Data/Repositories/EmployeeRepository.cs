﻿namespace FluffyAndOliver.Data.Repositories
{
    using System.Linq;

    using FluffyAndOliver.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The employee repository.
    /// </summary>
    public class EmployeeRepository : ReadOnlyGenericRepository<Employee, EmployeeContext>
    {
        /// <summary>
        /// The blog context.
        /// </summary>
        private readonly EmployeeContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            this.blogContext = context;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Employee"/>.
        /// </returns>
        public Employee Get(int id)
        {
            return this.blogContext.Set<Employee>().Include(e => e.Company).Include(e => e.Skills).FirstOrDefault(e => e.Id.Equals(id));
        }
    }
}

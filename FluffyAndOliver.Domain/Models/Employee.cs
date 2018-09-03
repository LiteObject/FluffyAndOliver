﻿namespace FluffyAndOliver.Domain.Models
{
    using System.Collections.Generic;

    using FluffyAndOliver.Shared;

    /// <summary>
    /// The employee.
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public virtual ICollection<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
    }
}
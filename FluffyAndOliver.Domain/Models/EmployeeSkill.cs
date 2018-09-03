namespace FluffyAndOliver.Domain.Models
{
    /// <summary>
    /// This is the join table
    /// </summary>
    public class EmployeeSkill : Entity
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the skill id.
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Gets or sets the skill.
        /// </summary>
        public Skill Skill { get; set; }
    }
}

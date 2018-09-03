namespace FluffyAndOliver.Shared
{
    using System;

    /// <summary>
    /// The base entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        public virtual string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        public virtual DateTime ModifiedOn { get; set; }
        
        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The boolean object.
        /// </returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The boolean object.
        /// </returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var theOtherObject = obj as Entity;

            if (ReferenceEquals(theOtherObject, null))
            {
                return false;
            }

            if (ReferenceEquals(this, theOtherObject))
            {
                return true;
            }

            if (this.GetType() != theOtherObject.GetType())
            {
                return false;
            }

            if (this.Id == 0 || theOtherObject.Id == 0)
            {
                return false;
            }

            return this.Id == theOtherObject.Id;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.GetType().ToString() + this.Id).GetHashCode();
        }
    }
}

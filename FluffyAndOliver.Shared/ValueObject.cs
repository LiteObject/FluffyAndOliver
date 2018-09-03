namespace FluffyAndOliver.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// The value object.
    /// </summary>
    /// <typeparam name="T">
    /// The type.
    /// </typeparam>
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The boolean,
        /// </returns>
        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x != null && x.Equals(y);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The boolean.
        /// </returns>
        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var t = this.GetType();
            var otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
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
            if (obj == null)
            {
                return false;
            }

            var other = obj as T;

            return this.Equals(other);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            var fields = this.GetFields();

            var startValue = 17;
            var multiplier = 59;

            var hashCode = startValue;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);

                if (value != null)
                {
                    hashCode = (hashCode * multiplier) + value.GetHashCode();
                }
            }

            return hashCode;
        }

        /// <summary>
        /// The get fields.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            var t = this.GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }
    }
}

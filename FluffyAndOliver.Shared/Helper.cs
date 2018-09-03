namespace FluffyAndOliver.Shared
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// A collection of helper methods.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// The find by key.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TEntity">
        /// The entity type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// The expression.
        /// </returns>
        public static Expression<Func<TEntity, bool>> BuildFindByKeyLambda<TEntity>(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, "Id");
            var constant = Expression.Constant(id);
            var equal = Expression.Equal(prop, constant);

            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}

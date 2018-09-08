namespace FluffyAndOliver.Shared
{
    using System;
    using System.Linq.Expressions;

    using FluffyAndOliver.Shared.Enums;
    using FluffyAndOliver.Shared.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A collection of helper methods.
    /// </summary>
    public static class Helper
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

        /// <summary>
        /// The convert state of disconnected entities.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="EntityState"/>.
        /// </returns>
        private static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        /// <summary>
        /// The fix state for disconnected entities.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void FixState(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IStateObject>())
            {
                var stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.State);
            }
        }
    }
}

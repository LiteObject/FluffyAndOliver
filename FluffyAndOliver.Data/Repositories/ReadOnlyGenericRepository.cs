namespace FluffyAndOliver.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using FluffyAndOliver.Shared;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TContext">
    /// The database context.
    /// </typeparam>
    public class ReadOnlyGenericRepository<TEntity, TContext> : IReadOnlyRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TContext context;

        /// <summary>
        /// The db set.
        /// </summary>
        private readonly DbSet<TEntity> dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyGenericRepository{TEntity,TContext}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ReadOnlyGenericRepository(TContext context)
        {
            this.context = context;
            this.dataSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dataSet.AsNoTracking().Where(predicate);
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<TEntity> FindBy(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.GetAllIncluding(includeProperties);
            var results = query.Where(predicate);
            return results;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TKey">
        /// The parameter type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get<TKey>(TKey id)
        {
            // return this.dataSet.Find(id); // Wont work with "AsNoTracking"
            return this.dataSet.AsNoTracking().SingleOrDefault(e => e.Id.Equals(id));
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dataSet.AsNoTracking();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.GetAllIncluding(includeProperties);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = this.dataSet.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}

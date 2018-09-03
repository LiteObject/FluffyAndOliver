namespace FluffyAndOliver.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// The Repository interface.
    /// IEnumerable vs IReadOnlyList. Source: https://enterprisecraftsmanship.com/2017/05/24/ienumerable-vs-ireadonlylist/
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type.
    /// </typeparam>
    public interface IReadOnlyRepository<TEntity>
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IReadOnlyList{T}"/>.
        /// </returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TKey">
        /// The identity key type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        Task<TEntity> Get<TKey>(TKey id);

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IReadOnlyList{T}"/>.
        /// </returns>
        Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}

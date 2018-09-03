namespace FluffyAndOliver.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FluffyAndOliver.Shared;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity.
    /// </typeparam>
    /// <typeparam name="TContext">
    /// The context.
    /// </typeparam>
    public class GenericRepository<TEntity, TContext> : ReadOnlyGenericRepository<TEntity, TContext>, IRepository<TEntity>
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
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity,TContext}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public GenericRepository(TContext context) : base(context)
        {
            this.context = context;
            this.dataSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Insert(TEntity entity)
        {
            await this.dataSet.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Update(TEntity entity)
        {
            this.dataSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TKey">
        /// The identifier key type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Delete<TKey>(TKey id)
        {
            var entity = await this.Get(id);
            this.dataSet.Remove(entity);
            await this.context.SaveChangesAsync();
        }
    }
}

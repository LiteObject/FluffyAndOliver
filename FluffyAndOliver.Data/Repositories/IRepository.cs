﻿namespace FluffyAndOliver.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
    {
		IEnumerable<TEntity> GetAll();
		TEntity Get<TKey>(TKey id);

		IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

	}
}

﻿using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts
{
    /// <summary>
    /// Repository for reading data
    /// </summary>
    /// <typeparam name="TEntity">Database entity type</typeparam>
    public interface IReadOnlyRepository<TEntity> : IRepository where TEntity : EntityBase
    {
        /// <summary>
        /// Reads all entities
        /// </summary>
        /// <returns>Entities from database</returns>
        IQueryable<TEntity> Read();
    }
}

using Database.UnitOfWork.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Database.UnitOfWork.EF.Services
{
    /// <inheritdoc/>
    public class QueryableAsyncExecutor : IQueryableAsyncExecutor
    {
        /// <inheritdoc/>
        public Task<T> FirstAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.FirstAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> FirstAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.FirstAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.FirstOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.FirstOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T> LastAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.LastAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> LastAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.LastAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.LastOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.LastOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T> MaxAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.MaxAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<TResult> MaxAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => query.MaxAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<T> MinAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.MinAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<TResult> MinAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => query.MinAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<decimal?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<decimal> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<double?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<double> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<float?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<float> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<int?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<int> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<long?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<long> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<T> SingleAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.SingleAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> SingleAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.SingleAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.SingleOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.SingleOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T[]> ToArrayAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.ToArrayAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);

        /// <inheritdoc/>
        public Task<List<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.ToListAsync(cancellationToken);
    }
}
